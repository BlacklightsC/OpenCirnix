using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

using Cirnix.JassNative.InterfaceAPI;
using Cirnix.JassNative.JassAPI;
using Cirnix.JassNative.Runtime;
using Cirnix.JassNative.Runtime.Utilities;
using Cirnix.JassNative.Runtime.Windows;
using Cirnix.JassNative.WarAPI;
using Cirnix.JassNative.WarAPI.Types;

namespace Cirnix.JassNative.JassDebugger
{
    public static class JassDebugger
	{
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate IntPtr sub_6F88FAB0Prototype(StringPtr cheatPtr);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate uint sub_6F924730Prototype();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate uint sub_6F925F00Prototype();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate uint sub_6F929670Prototype();

		private static sub_6F88FAB0Prototype sub_6F88FAB0;
		private static sub_6F924730Prototype sub_6F924730;
		private static sub_6F925F00Prototype sub_6F925F00;
		private static sub_6F929670Prototype sub_6F929670;

		private static string logsFolder;

		public static string JassTypeToString(JassType type)
		{
			string result;
			switch (type)
			{
				case JassType.Nothing:
					result = "nothing";
					break;
				case JassType.Type01:
					result = "type1";
					break;
				case JassType.Null:
					result = "null";
					break;
				case JassType.Code:
					result = "code";
					break;
				case JassType.Integer:
					result = "integer";
					break;
				case JassType.Real:
					result = "real";
					break;
				case JassType.String:
					result = "string";
					break;
				case JassType.Handle:
					result = "handle";
					break;
				case JassType.Boolean:
					result = "boolean";
					break;
				case JassType.IntegerArray:
					result = "integer array";
					break;
				case JassType.RealArray:
					result = "real array";
					break;
				case JassType.StringArray:
					result = "string array";
					break;
				case JassType.HandleArray:
					result = "handle array";
					break;
				case JassType.BooleanArray:
					result = "boolean array";
					break;
				default:
					result = "invalid";
					break;
			}
			return result;
		}

		public unsafe static string ByteCodeToString(OpCode* op, string split)
		{
			VirtualMachine* ptr = *GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine;
			string text = $"{split}0x{op->R1:X2}";
			OpCodeType opType = op->OpType;
			if (opType == OpCodeType.GetArray)
				text = $"{text}:{JassTypeToString((JassType)op->R1)}";
			text = $"{text}{split}0x{op->R2:X2}";
			switch (op->OpType)
			{
				case OpCodeType.Literal:
				case OpCodeType.GetVar:
				case OpCodeType.Code:
					text = $"{text}:{JassTypeToString((JassType)op->R2)}";
					break;
			}
			text = $"{text}{split}0x{op->R2:X2}";
			switch (op->OpType)
			{
				case OpCodeType.Local:
				case OpCodeType.Global:
				case OpCodeType.Constant:
				case OpCodeType.PopFuncArg:
					text = $"{text}:{JassTypeToString((JassType)op->R3)}";
					break;
			}
			text = $"{text}{split}0x{(byte)op->OpType:X2}{split}{op->OpType}";
			switch (op->OpType)
			{
				case OpCodeType.Function:
				case OpCodeType.Local:
				case OpCodeType.Global:
				case OpCodeType.Constant:
				case OpCodeType.PopFuncArg:
				case OpCodeType.GetVar:
				case OpCodeType.GetArray:
				case OpCodeType.SetVar:
				case OpCodeType.SetArray:
				case OpCodeType.Native:
				case OpCodeType.JassCall:
					return text + split + (*ptr->SymbolTable->StringPool->Nodes + op->Argument * sizeof(StringNode*) / sizeof(StringNode*))->Value;
				case OpCodeType.Literal:
					switch (op->R2)
					{
						case 5:
							text = $"{text}{split}{Memory.Read<float>(new IntPtr((void*)&op->Argument))}";
							goto IL_2FC;
						case 6:
							text = $"{text}{split}\"{(*ptr->SymbolTable->StringPool->Nodes + op->Argument * sizeof(StringNode*) / sizeof(StringNode*))->Value}\"";
							goto IL_2FC;
						case 8:
						{
							int argument = op->Argument;
							if (argument != 0)
							{
								if (argument != 1)
									text = $"{text}{split} = (boolean){argument}";
								else
									text = $"{text}{split} = true";
							}
							else
								text = $"{text}{split} = false";
							goto IL_2FC;
						}
					}
					text = $"{text}{split}{op->Argument}";
				IL_2FC:
					return text;
			}
			text = $"{text}{split}{op->Argument}";
			return text;
		}

		public static string VariableValueToString(IntPtr value, JassType type)
		{
			switch (type)
			{
				case JassType.Real:
					return BitConverter.ToSingle(BitConverter.GetBytes((int)value), 0).ToString();
				case JassType.String:
					return $"\"{GameFunctions.JassStringHandleToString(GameFunctions.JassStringIndexToJassStringHandle((int)value))}\"";
				case JassType.Handle:
					return value.ToString("X6");
				case JassType.Boolean:
					switch ((int)value)
                    {
						case 0: return "false";
						case 1: return "true";
						default: return "(boolean)" + (int)value;
					}
				default:
					return value.ToString();
			}
		}

		public unsafe static string VariableToString(Variable* variable, string split)
		{
			VirtualMachine* ptr = *GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine;
			string text = $"{variable->Type}{split}{variable->Type2}{split}{variable->Name.AsString()}";
			switch (variable->Type)
			{
				case JassType.IntegerArray:
				case JassType.RealArray:
				case JassType.StringArray:
				case JassType.HandleArray:
				case JassType.BooleanArray:
				{
					JassArray* ptr2 = (JassArray*)(void*)variable->Value;
					JassType jassType = (JassType)(variable->Type - JassType.Real);
					text = $"{text}{split}{jassType}";
					if (ptr2 == null)
						text += "[null]";
					else
					{
						text += "[";
						for (int i = 0; i < ptr2->Length; i++)
						{
							text += VariableValueToString(ptr2->Data[i * sizeof(IntPtr) / sizeof(IntPtr)], jassType);
							if (i < ptr2->Length - 1)
								text += ", ";
						}
						text += "]";
					}
					break;
				}
				default:
					text = $"{text}{split}{VariableValueToString(variable->Value, variable->Type)}";
					break;
			}
			return text;
		}

		public unsafe static void DumpFunctionToTrace(string name)
		{
			VirtualMachine* ptr = *GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine;
			HT_Node* ptr2 = ptr->FunctionTable->Lookup(name);
			if (ptr2 != null)
			{
				OpCode* value = (OpCode*)ptr2->Value;
				string text = string.Empty;
				int num = -1;
				while (value[num].OpType != OpCodeType.EndFunction)
				{
					text = $"{text}0x{num + 1:X4}{ByteCodeToString(value + num, "\t")}{Environment.NewLine}";
					num++;
				}
				Trace.WriteLine($"Function '{name}'");
			}
			else
				Trace.WriteLine($"Function '{name}' could not be found!");
		}

		public unsafe static void DumpFunctionToText(string name, string filename)
		{
			using (FileStream fileStream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.Write))
			using (StreamWriter streamWriter = new StreamWriter(fileStream))
			{
				VirtualMachine* ptr = *GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine;
				HT_Node* ptr2 = ptr->FunctionTable->Lookup(name);
				if (ptr2 != null)
				{
					OpCode* value = (OpCode*)ptr2->Value;
					string text = string.Empty;
					int num = -1;
					while (value[num].OpType != OpCodeType.EndFunction)
					{
						text = $"{text}0x{num + 1:X4}{ByteCodeToString(value + num, "\t")}{Environment.NewLine}";
						num++;
					}
					streamWriter.WriteLine(text);
					Trace.WriteLine($"Function '{name}' dumped to '{filename}'");
				}
				else
					Trace.WriteLine($"Function '{name}' could not be found!");
			}
		}

		public unsafe static void DumpFunctionToCSV(string name, string filename)
		{
			using (FileStream fileStream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.Write))
			using (StreamWriter streamWriter = new StreamWriter(fileStream))
			{
				VirtualMachine* ptr = *GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine;
				HT_Node* ptr2 = ptr->FunctionTable->Lookup(name);
				if (ptr2 != null)
				{
					OpCode* value = (OpCode*)ptr2->Value;
					string text = string.Empty;
					int num = -1;
					while (value[num].OpType != OpCodeType.EndFunction)
					{
						text = $"{text}0x{num + 1:X4}{ByteCodeToString(value + num, ";")}{Environment.NewLine}";
						num++;
					}
					streamWriter.WriteLine(text);
					Trace.WriteLine($"Function '{name}' dumped to '{filename}'");
				}
				else
					Trace.WriteLine($"Function '{name}' could not be found!");
			}
		}

		private unsafe static void DumpGlobalsToTrace()
		{
			Variable*[] allGlobals = (*GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine)->GetAllGlobals();
			Trace.WriteLine($"GlobalCount: {allGlobals.Length}");
			foreach (Variable* variable in allGlobals)
				Trace.WriteLine(VariableToString(variable, " "));
		}

		private unsafe static void DumpGlobalsToText(string filename)
		{
			using (FileStream fileStream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.Write))
			using (StreamWriter streamWriter = new StreamWriter(fileStream))
			{
				Variable*[] allGlobals = (*GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine)->GetAllGlobals();
				streamWriter.WriteLine($"GlobalCount: {allGlobals.Length}");
				foreach (Variable* variable in allGlobals)
					streamWriter.WriteLine(VariableToString(variable, " "));
				Trace.WriteLine($"Globals dumped to '{filename}'");
			}
		}

		private unsafe static void DumpGlobalsToCSV(string filename)
		{
			using (FileStream fileStream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.Write))
			using (StreamWriter streamWriter = new StreamWriter(fileStream))
			{
				Variable*[] allGlobals = (*GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine)->GetAllGlobals();
				streamWriter.WriteLine($"GlobalCount: {allGlobals.Length}");
				foreach (Variable* variable in allGlobals)
					streamWriter.WriteLine(VariableToString(variable, ";"));
				Trace.WriteLine($"Globals dumped to '{filename}'");
			}
		}

		private unsafe static void DumpLocalsToTrace()
		{
			Variable*[] allLocals = (*GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine)->GetAllLocals();
			Trace.WriteLine($"LocalCount: {allLocals.Length}");
			foreach (Variable* variable in allLocals)
				Trace.WriteLine(VariableToString(variable, " "));
		}

		public unsafe static void OnGameLoad()
		{
			Script.VirtualMachine__RunCodeCallback += Jass_VirtualMachine__RunCodeCallback;
			IntPtr moduleHandle = Kernel32.GetModuleHandle("game.dll");
			sub_6F88FAB0 = Memory.InstallHook(moduleHandle + 0x88FAB0, new sub_6F88FAB0Prototype(sub_6F88FAB0Hook), true, false);
			sub_6F924730 = Memory.InstallHook(moduleHandle + 0x924730, new sub_6F924730Prototype(sub_6F924730Hook), true, false);
			sub_6F925F00 = Memory.InstallHook(moduleHandle + 0x925F00, new sub_6F925F00Prototype(sub_6F925F00Hook), true, false);
			sub_6F929670 = Memory.InstallHook(moduleHandle + 0x929670, new sub_6F929670Prototype(sub_6F929670Hook), true, false);
			logsFolder = Path.Combine(Path.GetDirectoryName(new Uri(typeof(EntryPoint).Assembly.CodeBase).LocalPath), "logs");
			if (!Directory.Exists(logsFolder))
				Directory.CreateDirectory(logsFolder);
		}

		private static IEnumerable<string> Split(this string str, Func<char, bool> controller)
		{
			int num, nextPiece = 0;
			for (int c = 0; c < str.Length; c = num + 1)
			{
				if (controller(str[c]))
				{
					yield return str.Substring(nextPiece, c - nextPiece);
					nextPiece = c + 1;
				}
				num = c;
			}
			yield return str.Substring(nextPiece);
			yield break;
		}

		private static string TrimMatchingQuotes(this string input, char quote)
		{
			if (input.Length >= 2 && input[0] == quote && input[input.Length - 1] == quote)
				return input.Substring(1, input.Length - 2);
			else
				return input;
		}

		private static IEnumerable<string> SplitCommandLine(string commandLine)
		{
			bool inQuotes = false;
			bool isEscaping = false;
			return from arg in commandLine.Split(c =>
			{
				bool result;
				if (c == '\\' && !isEscaping)
				{
					isEscaping = true;
					result = false;
				}
				else
				{
					if (c == '"' && !isEscaping)
					{
						inQuotes = !inQuotes;
					}
					isEscaping = false;
					result = !inQuotes && char.IsWhiteSpace(c);
				}
				return result;
			})
				   select arg.Trim().TrimMatchingQuotes('"').Replace("\\\"", "\"") into arg
				   where !string.IsNullOrEmpty(arg)
				   select arg;
		}

		private static void HandleFuncDump(List<string> commands)
		{
			if (commands.Count < 2) return;

			switch (commands[0].ToUpper())
			{
				case "TRACE": DumpFunctionToTrace(commands[1]); break;
				case "TXT":
					if (commands.Count < 3) return;
					if (Path.IsPathRooted(commands[2]))
						DumpFunctionToText(commands[1], commands[2]);
					else
						DumpFunctionToText(commands[1], Path.Combine(logsFolder, commands[2]));
					break;
				case "CSV":
					if (commands.Count < 3) return;
					if (Path.IsPathRooted(commands[2]))
						DumpFunctionToCSV(commands[1], commands[2]);
					else
						DumpFunctionToCSV(commands[1], Path.Combine(logsFolder, commands[1]));
					break;
			}
		}

		private unsafe static void HandleVarDump(List<string> commands)
		{
			Trace.WriteLine("=== VARIABLE DUMP ===");
			if (commands.Count >= 1)
			{
				string text = commands[0];
				Trace.WriteLine($"Variable: {text}");
				VirtualMachine* ptr = *GameFunctions.GetThreadLocalStorage()->Jass.AsUnsafe()->VirtualMachine;
				Variable* ptr2 = (Variable*)ptr->GlobalTable->Lookup(text);
				if (ptr2 != null)
				{
					Trace.WriteLine($" - Value: {ptr2->Value}");
					Trace.WriteLine($" - Type: {ptr2->Type}");
					Trace.WriteLine($" - Type2: {ptr2->Type2}");
					Trace.WriteLine($" - IsFunctionArgument: {ptr2->IsFunctionArgument}");
				}
				else
					Trace.WriteLine(" - NOT FOUND!");
			}
			else
			{
				Trace.WriteLine("Invalid usage");
				Trace.WriteLine("Usage: SCDBG VARDUMP <name>");
			}
		}

		private static void HandleGlobalDump(List<string> commands)
		{
			if (commands.Count < 1) return;
			switch (commands[0].ToUpper())
			{
				case "TRACE": DumpGlobalsToTrace(); break;
				case "TXT":
					if (commands.Count < 2) return;
					if (Path.IsPathRooted(commands[1]))
						DumpGlobalsToText(commands[1]);
					else
						DumpGlobalsToText(Path.Combine(logsFolder, commands[1]));
					break;
				case "CSV":
					if (commands.Count < 2) return;
					if (Path.IsPathRooted(commands[1]))
						DumpGlobalsToCSV(commands[1]);
					else
						DumpGlobalsToCSV(Path.Combine(logsFolder, commands[1]));
					break;
			}
		}

		private static void HandleLocalDump(List<string> commands)
		{
		}

		private static void HandleTest(List<string> commands)
		{
		}

		private static IntPtr sub_6F88FAB0Hook(StringPtr cheat)
		{
			List<string> list = SplitCommandLine(cheat.AsString()).ToList();
			if (list.Count >= 2 && list[0].Equals("SCDBG", StringComparison.OrdinalIgnoreCase))
				switch (list[1].ToUpper())
				{
					case "FUNCDUMP": HandleFuncDump(list.Skip(2).ToList()); break;
					case "GLOBALDUMP": HandleGlobalDump(list.Skip(2).ToList()); break;
					case "LOCALDUMP": HandleLocalDump(list.Skip(2).ToList()); break;
					case "VARDUMP": HandleVarDump(list.Skip(2).ToList()); break;
					case "TEST": HandleTest(list.Skip(2).ToList()); break;
				}
			return sub_6F88FAB0(cheat);
		}

		private static uint sub_6F924730Hook()
		{
			uint num = sub_6F924730();
			Trace.WriteLine($"LOOP.tick = {num} ms");
			return num;
		}

		private static uint sub_6F925F00Hook()
		{
			uint num = sub_6F925F00();
			Trace.WriteLine($"BNET.tick = {num} ms");
			return num;
		}

		private static uint sub_6F929670Hook()
		{
			uint num = sub_6F929670();
			Trace.WriteLine($"LTCP.tick = {num} ms");
			return num;
		}

		private unsafe static void Jass_VirtualMachine__RunCodeCallback(VirtualMachine* vm, OpCode* op, IntPtr a3, uint opLimit, IntPtr a5, CodeResult result)
		{
			if (result == CodeResult.Success || result == CodeResult.ThreadPause || result == CodeResult.ThreadSync) return;
			if (!vm->TryGetOpCodeFunctionName(op, out string text))
				text = "unknown function";
			switch (result)
            {
				case CodeResult.OpLimit:
					Interface.GameUI->ChatMessage->WriteLine($"[Debugger] |cffff0000Error|r: Op limit({opLimit}) exceeded in {text}.", Color.White, 60f);
					break;
				case CodeResult.VariableUninitialized:
					Interface.GameUI->ChatMessage->WriteLine($"[Debugger] |cffff0000Error|r: Uninitialized variable read in {text}.", Color.White, 60f);
					break;
				case CodeResult.DivideByZero:
					Interface.GameUI->ChatMessage->WriteLine($"[Debugger] |cffff0000Error|r: Divide by zero in {text}.", Color.White, 60f);
					break;
				default:
					Interface.GameUI->ChatMessage->WriteLine($"[Debugger] |cffff0000Error|r: Unknown error({result}) in {text}.", Color.White, 60f);
					break;
			}
		}
	}
}
