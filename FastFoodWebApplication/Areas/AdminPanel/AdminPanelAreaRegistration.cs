using System.Web.Mvc;

namespace FastFoodWebApplication.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPanel_default",
                "AdminPanel/{controller}/{action}/{id}",
                new { action = "Login", id = UrlParameter.Optional },
                new[] { "FastFoodWebApplication.Areas.AdminPanel.Controllers" }
            );
        }
    }
}