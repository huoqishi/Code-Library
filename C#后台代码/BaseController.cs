using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wdage.Ldd.EF_ForModel;

namespace Wdage.Ldd.WebUI.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        //定义一个基类的UserInfo对象
        public user CurrentUserInfo { get; set; }

        /// <summary>
        /// 重写基类在Action之前执行的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ////---------
            //Session["User"] = new user() { nickname = "火骑士空空", UserGuid = "75df2a84e26c427c9336b26a5eb65170", openid = "olzRYwMvBIsLngr0Wtze2b_zOJkI" };
            //temp.OpenId = "ov1YDs8pD1jFg026SGrr6V7ZAa8Q";
            //-------------


            CurrentUserInfo = Session["User"] as user;
            //

            //检验用户是否已经登录，如果登录则不执行，否则则执行下面的跳转代码
            if (CurrentUserInfo == null || CurrentUserInfo.UserGuid == null)
            {
                var myHeader = Request.Headers;
                if (myHeader["X-Requested-With"] != null)
                {
                    //myHeader["session-expired"] = "expired";
                    Response.Headers.Add("session-expired", "expired");
                    //X-AspNetMvc-Version: 4.0
                    //Server: Microsoft-IIS/8.0
                    //X-AspNet-Version: 4.0.30319
                    //X-Powered-By: ASP.NET

                    HttpContext.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    //Response.Redirect("/home/activity");
                    Response.Write("should sign!");
                }
                Response.End();
                return;
            }
            //if (string.IsNullOrEmpty(CurrentUserInfo.OpenId))//如果在微信上就把条件改成phone==string.Empty或string.IsNullOrEmpty(phone);
            //{
            //    var myHeader = Request.Headers;
            //    if (!string.IsNullOrEmpty(Request["x-requested-with"]))
            //    {
            //        Response.Write("...");
            //        Response.End();
            //        return;
            //    }
            //    else
            //    {
            //        Response.Redirect("/sign/Register");
            //    }
            //    Response.Redirect("/Sign/Register");
            //    return;
            //}
        }
    }
}
