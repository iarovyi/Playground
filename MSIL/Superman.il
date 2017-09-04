.namespace ILExperiments {
    .class public Superman extends ILExperiments.Man {

        .method public specialname void .ctor(){
            ldarg.0;
            call instance void .base::.ctor();
            ret;
        }

        .method public virtual void SayHi()
        {
            .override ILExperiments.Man::SayHi

            ldstr "Hi, I am superman"
            call void [mscorlib]System.Console::WriteLine(string)
            ret
        }
    }
}