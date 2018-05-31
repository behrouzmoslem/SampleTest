using DataStructure;

namespace Sample.Test.Builders
{
    public class ReceptionBuilder : Builder<ReceptionDs>
    {
        public override ReceptionDs Build()
        {
            var result = base.Build();
            result.Doctor.MedicalNo = "00029999";
            result.ReceptionDate = "97/03/10";
            return result;
        }
    }
}