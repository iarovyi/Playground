
//----Program header
.assembly extern  mscorlib { auto }
.assembly ConsoleApp  { }
.module ConsoleApp.exe

#include "Man.il"
#include "Superman.il"
#define DEFLT_CTOR ".method public specialname void .ctor(){ldarg.0; call instance void .base::.ctor(); ret;}"

//----------- Aliasing
//.typedef [mscorlib]System.Console as Cons
//.typedef method void Console::WriteLine(int32) as PrintNumber

.namespace ILExperiments {
    .class  private auto ansi beforefieldinit Program extends [mscorlib]System.Object
    {

        .method  private hidebysig static void Main(string[] args) cil managed 
        {
            .entrypoint
            .maxstack 8


            /*var hashedManually = new Man()
            {
                Age = 77,
                FirstName = "James",
                LastName = "Bond",
                BirthDate = new DateTime(2017, 1, 2)
            };
            int hashCode = hashedManually.GetHashCode();
            Console.WriteLine(hashCode);
            Console.ReadKey();*/
            newobj       instance void ILExperiments.Man::.ctor()
            dup          
            ldc.i4.s     77
            callvirt     instance void ILExperiments.Man::set_Age(int32)
            dup          
            ldstr        "James"
            callvirt     instance void ILExperiments.Man::set_FirstName(string)
            dup          
            ldstr        "Bond"
            callvirt     instance void ILExperiments.Man::set_LastName(string)
            dup          
            ldc.i4       2017
            ldc.i4.1     
            ldc.i4.2     
            newobj       instance void [mscorlib]System.DateTime::.ctor(int32, int32, int32)
            callvirt     instance void ILExperiments.Man::set_BirthDate(valuetype [mscorlib]System.DateTime)

            callvirt     instance int32 [mscorlib]System.Object::GetHashCode()

            call         void [mscorlib]System.Console::WriteLine(int32)  //call         PrintNumber



            newobj       instance void ILExperiments.Superman::.ctor()
            callvirt     instance void ILExperiments.Superman::SayHi()



            call         valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey()
            pop          
            ret          
        }

        DEFLT_CTOR
  }
}
