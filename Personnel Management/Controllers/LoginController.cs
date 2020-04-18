using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Personnel_Management.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

       
        public ActionResult LoginWeb()
        {
            return View();
        }

      
        public ActionResult LoginWebs(string name,string pwd) {
        
            using (PersonnelEntities1 ent =new PersonnelEntities1 ())
            {
                var list= (from Users in ent.UserInfo 
                    where Users.UserName==name && Users.Password==pwd  
                    select new{
                     Users.ID,
                     Users.UserName
                    }
                ).ToList();
              //UserInfo  user= ent.UserInfo.SingleOrDefault(x => x.UserName == name && x.Password == pwd);

                if (list.Count>0)
                {                   
                    return Json(new {flag=true, mag = "登录成功！" });
                }
                else {                 
                    return Json(new { flag = false, mag = "登录失败！" });               
                }
            }

          
        }

     

    }
}
