using System.Collections.Generic;

namespace Swart.DomainDrivenDesign.Domain
{
    public class ValidationResult
    {
        public ValidationResult(string errorMessage)
            :this(errorMessage, new List<string>())
        {            
        }
        protected ValidationResult(ValidationResult validationResult)
            :this(validationResult.ErrorMessage, validationResult.MemberNames)
        {            
        }
        public ValidationResult(string errorMessage, IEnumerable<string> memberNames)
        {
            ErrorMessage = errorMessage;
            MemberNames =new List<string>(memberNames);
        }

        public string ErrorMessage { get; set; }
        public IEnumerable<string> MemberNames { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", ErrorMessage, string.Join(",", MemberNames));
        }
    }
}
