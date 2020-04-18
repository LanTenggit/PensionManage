using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personnel_Management.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Person/
        public ActionResult personnel() {

            return View();
        
        }



        public ActionResult personnels(int page=1,int rows=10) {
            using(PersonnelEntities1 ent =new PersonnelEntities1()){
                var list = (from users in ent.UserInfo
                            join du in ent.Duties on users.DutiesID equals du.ID
                            join dep in ent.DePartment on users.DepartmentID equals dep.ID
                            select new { 
                            users.ID,
                            users.UserName,
                            users.Password,
                            users.Sex,
                            users.IDCard,
                            du.Dumane,
                            dep.DeMane
                            }).ToList();
                

                int total = list.Count();
                var newlist = list.Skip((page - 1) * rows).Take(rows).ToList();

                return Json(new {total=list.Count,rows=newlist });
            
            }
        }


        //性别
        public ActionResult SexType() {
            Sex s1 = new Sex(1,"男");
            Sex s2 = new Sex(2,"女");
            List<Sex> list = new List<Sex>();
            list.Add(s1);
            list.Add(s2);
            return Json(list);
        
        }

        //部门
        public ActionResult DepartmentType()
        {
            using (PersonnelEntities1 ent = new PersonnelEntities1())
            {
                var list = ent.DePartment.ToList();
                return Json(list);
            }
           
        }
        //职位
        public ActionResult DutiesType()
        {
            using (PersonnelEntities1 ent = new PersonnelEntities1())
            {
                var list = ent.Duties.ToList();
                return Json(list);
            }
           
        }

        //添加
        public ActionResult add(UserInfo u)
        {
            string str = "";
            using (PersonnelEntities1 ent=new PersonnelEntities1 ()) {


                UserInfo user = new UserInfo();
                user.UserName =u.UserName ;
                user.Password = u.Password;
                user.Sex = u.Sex;
                user.IDCard = u.IDCard;
                user.DepartmentID = u.DepartmentID;
                user.DutiesID = u.DutiesID;
                ent.UserInfo.Add(user);
                if (ent.SaveChanges() > 0)
                {
                    str = "新增成功！";
                }
                else
                {
                    str = "新增失败！";
                
                }
            }

            return Json(str);
        
        }
      
        //修改
        public ActionResult edit(UserInfo user, string DepartmentID, string DutiesID)
        {
            var a = new object();
            using (PersonnelEntities1 ent=new PersonnelEntities1 ()) {
                UserInfo u1 = ent.UserInfo.Find(user.ID);
                u1.UserName = user.UserName;
                u1.Sex = user.Sex;
                u1.Password = user.Password;
                u1.IDCard = user.IDCard;

                switch (DepartmentID)
                {
                    case "研发部":
                        DepartmentID = "1";
                        break;
                    case "招商部":
                        DepartmentID = "2";
                        break;
                    case "管理部":
                        DepartmentID = "3";
                        break;
                    case "人力资源部":
                        DepartmentID = "4";
                        break;
                    default:
                        break;
                }
                switch (DutiesID)
                {
                    case "员工":
                        DutiesID = "1";
                        break;
                    case "组长":
                        DutiesID = "2";
                        break;
                    case "主管":
                        DutiesID = "3";
                        break;
                    case "经理":
                        DutiesID = "4";
                        break;
                    default:
                        break;
                }

                u1.DepartmentID = int.Parse(DepartmentID);
                u1.DutiesID =Convert.ToInt32( DutiesID);

                if (ent.SaveChanges ()>0)
                {
                    a = new
                    {

                        meg = "修改成功！",
                        start = "true"
                    };
                }
                else
                {
                    a = new
                    {

                        meg = "修改失败！",
                        start = "false"
                    };
                }
               


            }


            return Json (a);
        }

        //删除
        public ActionResult deleId(string ID) {

            var a = new object();
            int n = 0;
            using (PersonnelEntities1 ent = new PersonnelEntities1())
            {

                string listId = ID.TrimEnd(',');

                string[] id = listId.Split(',');

                foreach (string item in id)
                {
                    UserInfo user = ent.UserInfo.Find(Convert.ToInt32(item));
                    ent.UserInfo.Remove(user);
                    ent.SaveChanges();
                    n++;
                }


                if (id.Length == n)
                {

                    a = new
                    {

                        meg = "删除成功",
                        start = "true"
                    };

                }
                else
                {
                    a = new
                    {

                        meg = "删除失败",
                        start = "false"
                    };
                }

            }

            return Json(a);
        
        
        
        }

        //查询 
        public ActionResult search( string Department, string Duties, string UserName, string Sex ,int page = 1, int rows = 10)
        {
            using(PersonnelEntities1 ent =new PersonnelEntities1 ()){
                var list = (from users in ent.UserInfo
                            join du in ent.Duties on users.DutiesID equals du.ID
                            join dep in ent.DePartment on users.DepartmentID equals dep.ID
                            select new
                            {
                                users.ID,
                                users.UserName,
                                users.Password,
                                users.Sex,
                                users.IDCard,
                                du.Dumane,
                                dep.DeMane
                            });
           
                if (!string.IsNullOrWhiteSpace(UserName))
                {
                    list = list.Where(a => a.UserName.Contains(UserName));
                }
                if (!string.IsNullOrWhiteSpace(Sex))
                {
                    list = list.Where(a => a.Sex.Contains(Sex));
                }

                if (!string.IsNullOrWhiteSpace(Department))
                {
                    list = list.Where(a => a.DeMane.Contains(Department));
                }
                if (!string.IsNullOrWhiteSpace(Duties))
                {
                    list = list.Where(a => a.Dumane.Contains(Duties));
                }

             
                var newlist = list.OrderBy(x=>x.ID).Skip((page - 1) * rows).Take(rows).ToList();

                return Json(new { total = list.Count(), rows = newlist });
            
            }
          
        
        }


    }
}
