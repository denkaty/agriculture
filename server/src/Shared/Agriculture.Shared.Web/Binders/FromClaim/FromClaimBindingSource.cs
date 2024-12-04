using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Agriculture.Shared.Web.Binders.FromClaim
{
    public static class FromClaimBindingSource
    {
        public static readonly BindingSource Claim = new(
          "Claim",
          "BindingSource_Claim",
          isGreedy: false,
          isFromRequest: true);
    }
}
