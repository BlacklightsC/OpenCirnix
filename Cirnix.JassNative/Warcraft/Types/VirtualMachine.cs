using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct VirtualMachine
  {
    public IntPtr field0000;
    public IntPtr field0004;
    public IntPtr field0008;
    public IntPtr field000C;
    public IntPtr field0010;
    public IntPtr field0014;
    public IntPtr field0018;
    public IntPtr field001C;
    public IntPtr CurrentOpcode;
    public IntPtr field0024;
    public IntPtr field0028;
    public IntPtr field002C;
    public IntPtr field0030;
    public IntPtr field0034;
    public IntPtr field0038;
    public IntPtr field003C;
    public IntPtr field0040;
    public int MaxOperations;
    public IntPtr field0048;
    private unsafe fixed byte Variables[10240];
    public IntPtr field284C;
    public IntPtr field2850;
    public IntPtr field2854;
    public unsafe SymbolTable* SymbolTable;
    public unsafe Hashtable* GlobalTable;
    public IntPtr field2860;
    public IntPtr field2864;
    public unsafe LocalScope* LocalTable;
    public IntPtr field286C;
    public IntPtr JumpTable;
    public IntPtr StringTable;
    public IntPtr field2878;
    public IntPtr field287C;
    public IntPtr field2880;
    public unsafe Hashtable* FunctionTable;
    public IntPtr field2888;
    public IntPtr field288C;
    public IntPtr field2890;
    public IntPtr field2894;
    public IntPtr field2898;
    public IntPtr field289C;
    public IntPtr DecrementHandleFunction;
    public IntPtr HandleTable;
    public IntPtr table28A8;
    public IntPtr table28AC;
    public IntPtr table28B0;

    public unsafe bool TryGetOpCodeFunctionName(OpCode* op, out string name)
    {
      while (op->OpType != OpCodeType.Function)
      {
        op += -1;
        if (op < this.SymbolTable->FirstOperation)
        {
          name = string.Empty;
          return false;
        }
      }
      name = this.SymbolTable->StringPool->Nodes[op->Argument]->Value;
      return true;
    }

    public unsafe Variable*[] GetAllLocals()
    {
      HT_Node*[] allValues = (&this.LocalTable->Locals)->GetAllValues();
      Variable*[] variablePtrArray = new Variable*[allValues.Length];
      for (int index = 0; index < allValues.Length; ++index)
        variablePtrArray[index] = (Variable*) allValues[index];
      return variablePtrArray;
    }

    public unsafe Variable*[] GetAllGlobals()
    {
      HT_Node*[] allValues = this.GlobalTable->GetAllValues();
      Variable*[] variablePtrArray = new Variable*[allValues.Length];
      for (int index = 0; index < allValues.Length; ++index)
        variablePtrArray[index] = (Variable*) allValues[index];
      return variablePtrArray;
    }
  }
}
