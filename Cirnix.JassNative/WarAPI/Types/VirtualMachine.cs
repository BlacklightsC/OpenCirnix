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
        public IntPtr has_sleep;
        public IntPtr field0038;
        public IntPtr field003C;
        public IntPtr field0040;
        public int MaxOperations;
        public IntPtr field0048;
        private unsafe fixed byte Variables[0x2800];
        public IntPtr field284C;
        public IntPtr index;
        public IntPtr field2854;
        public unsafe SymbolTable* SymbolTable; // YDWE::symbol_table_t* symbol_table
        public unsafe Hashtable* GlobalTable;   // YDWE::hashtable::variable_table* global_table
        public IntPtr field2860;
        public IntPtr field2864;
        public unsafe LocalScope* LocalTable;   // YDWE::stackframe_t* stackframe
        public IntPtr field286C;
        public IntPtr JumpTable;
        public IntPtr StringTable;              // YDWE::hashtable::string_fasttable* string_table
        public IntPtr field2878;
        public IntPtr field287C;
        public IntPtr field2880;
        public unsafe Hashtable* FunctionTable;
        public IntPtr code_table;
        public IntPtr field288C;
        public IntPtr field2890;
        public IntPtr field2894;
        public IntPtr field2898;
        public IntPtr field289C;
        public IntPtr DecrementHandleFunction;  // YDWE::uintptr_t set_handle_reference
        public IntPtr HandleTable;              // YDWE::handle_table_t** handle_table
        public IntPtr table28A8;
        public IntPtr table28AC;
        public IntPtr table28B0;

        public unsafe bool TryGetOpCodeFunctionName(OpCode* op, out string name)
        {
            while (op->OpType != OpCodeType.Function)
            {
                op += -1;
                if (op < SymbolTable->FirstOperation)
                {
                    name = string.Empty;
                    return false;
                }
            }
            name = SymbolTable->StringPool->Nodes[op->Argument]->Value;
            return true;
        }

        public unsafe Variable*[] GetAllLocals()
        {
            HT_Node*[] allValues = (&LocalTable->Locals)->GetAllValues();
            Variable*[] variablePtrArray = new Variable*[allValues.Length];
            for (int index = 0; index < allValues.Length; ++index)
                variablePtrArray[index] = (Variable*)allValues[index];
            return variablePtrArray;
        }

        public unsafe Variable*[] GetAllGlobals()
        {
            HT_Node*[] allValues = GlobalTable->GetAllValues();
            Variable*[] variablePtrArray = new Variable*[allValues.Length];
            for (int index = 0; index < allValues.Length; ++index)
                variablePtrArray[index] = (Variable*)allValues[index];
            return variablePtrArray;
        }
    }
}