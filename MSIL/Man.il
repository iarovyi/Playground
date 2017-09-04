
.namespace ILExperiments {
    //auto - automatic class layout, other options: sequential, explicit
    //ansi - mode of string conversion within the class when interoperating with the unmanaged code. other options: unicode, autochar
    //beforefieldinit - this type can be initialized (its .cctor run) any time before the first access to a static field.
    //                  if this flag is not set, the type is initialized before the first access to one of its static fields or methods or before the first instantiation of the type.

    .class  public auto ansi beforefieldinit Man extends [mscorlib]System.Object
    {
        .field  private string '<FirstName>k__BackingField'
        .field  private string '<LastName>k__BackingField'
        .field  private int32 '<Age>k__BackingField'
        .field  private valuetype [mscorlib]System.DateTime '<BirthDate>k__BackingField'
        .field  private valuetype [mscorlib]System.DateTimeKind '<Enum>k__BackingField'

        .method  public hidebysig specialname instance string get_FirstName() cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldfld        string ILExperiments.Man::'<FirstName>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance void set_FirstName(string 'value') cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldarg.1      // 'value'
            stfld        string ILExperiments.Man::'<FirstName>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance string get_LastName() cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldfld        string ILExperiments.Man::'<LastName>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance void set_LastName(string 'value') cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldarg.1      // 'value'
            stfld        string ILExperiments.Man::'<LastName>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance int32 get_Age() cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldfld        int32 ILExperiments.Man::'<Age>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance void set_Age(int32 'value') cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldarg.1      // 'value'
            stfld        int32 ILExperiments.Man::'<Age>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance valuetype [mscorlib]System.DateTime get_BirthDate() cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldfld        valuetype [mscorlib]System.DateTime ILExperiments.Man::'<BirthDate>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance void set_BirthDate(valuetype [mscorlib]System.DateTime 'value') cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldarg.1      // 'value'
            stfld        valuetype [mscorlib]System.DateTime ILExperiments.Man::'<BirthDate>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance valuetype [mscorlib]System.DateTimeKind get_Enum() cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldfld        valuetype [mscorlib]System.DateTimeKind ILExperiments.Man::'<Enum>k__BackingField'
            ret          
        }

        .method  public hidebysig specialname instance void set_Enum(valuetype [mscorlib]System.DateTimeKind 'value') cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            ldarg.1      // 'value'
            stfld        valuetype [mscorlib]System.DateTimeKind ILExperiments.Man::'<Enum>k__BackingField'
            ret          
        }

        .property  instance string FirstName() 
        {
            .get instance string ILExperiments.Man::get_FirstName() 
            .set instance void ILExperiments.Man::set_FirstName( string) 
        }

        .property  instance string LastName() 
        {
            .get instance string ILExperiments.Man::get_LastName() 
            .set instance void ILExperiments.Man::set_LastName( string) 
        }

        .property  instance int32 Age() 
        {
            .get instance int32 ILExperiments.Man::get_Age() 
            .set instance void ILExperiments.Man::set_Age( int32) 
        }

        .property  instance valuetype [mscorlib]System.DateTime BirthDate() 
        {
            .get instance valuetype [mscorlib]System.DateTime ILExperiments.Man::get_BirthDate() 
            .set instance void ILExperiments.Man::set_BirthDate( valuetype [mscorlib]System.DateTime) 
        }

        .property  instance valuetype [mscorlib]System.DateTimeKind Enum() 
        {
            .get instance valuetype [mscorlib]System.DateTimeKind ILExperiments.Man::get_Enum() 
            .set instance void ILExperiments.Man::set_Enum( valuetype [mscorlib]System.DateTimeKind) 
        }

        .method  public hidebysig specialname rtspecialname instance void .ctor() cil managed 
        {
            .maxstack 8

            ldarg.0      // this
            call         instance void [mscorlib]System.Object::.ctor()
            ret          
        }

        .method public virtual void SayHi()
	    {
            ldstr "Hi, I am man"
            call void [mscorlib]System.Console::WriteLine(string)
            ret
        }

        //hidebysig - is not used by CLR, only for compilers. The method hides all methods of the parent classes that have a matching signature and name (as opposed to having a matching name only)
        .method  public hidebysig virtual instance int32 GetHashCode() cil managed 
        {
            .maxstack 2
            .locals  init (
                [0] valuetype [mscorlib]System.DateTime BirthDateVar
            )

            //var hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
            ldarg.0      // this
            call         instance string ILExperiments.Man::get_FirstName()
            brtrue.s     HasName
            ldc.i4.0     
            br.s         ProcessLastName
        HasName:     
            ldarg.0      // this
            call         instance string ILExperiments.Man::get_FirstName()
            callvirt     instance int32 [mscorlib]System.Object::GetHashCode()

            //hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0)
        ProcessLastName:     
            ldc.i4       397
            mul          
            ldarg.0      // this
            call         instance string ILExperiments.Man::get_LastName()
            brtrue.s     HasLastName
            ldc.i4.0     
            br.s         XorForLastName
        HasLastName:    
            ldarg.0      // this
            call         instance string ILExperiments.Man::get_LastName()
            callvirt     instance int32 [mscorlib]System.Object::GetHashCode()
        XorForLastName: 
            xor          

            //hashCode = (hashCode * 397) ^ Age;
            ldc.i4       397
            mul          
            ldarg.0      // this
            call         instance int32 ILExperiments.Man::get_Age()
            xor          

            //hashCode = (hashCode * 397) ^ BirthDate.GetHashCode();
            ldc.i4       397
            mul          
            ldarg.0      // this
            call         instance valuetype [mscorlib]System.DateTime ILExperiments.Man::get_BirthDate()
            stloc        BirthDateVar   //Equivalent to: stloc.0 Move from stack to local variable at slot 0 (BirthDateVar)
            ldloca.s     BirthDateVar   //copy value of local variable back to stack
            call         instance int32 [mscorlib]System.DateTime::GetHashCode()
            xor          

            //hashCode = (hashCode * 397) ^ (int) Enum;
            ldc.i4       397
            mul          
            ldarg.0      // this
            call         instance valuetype [mscorlib]System.DateTimeKind ILExperiments.Man::get_Enum()
            xor         

            ret
        }
   }
}
