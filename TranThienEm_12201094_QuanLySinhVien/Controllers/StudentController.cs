using Microsoft.AspNetCore.Mvc;
using TranThienEm_12201094_QuanLySinhVien.Models;

namespace TranThienEm_12201094_QuanLySinhVien.Controllers
{
    
    public class StudentController : Controller
    {
        [Route("HomeStudent")]
        [Route("Student")]
        [Route("Student/ListAll")]
        [Route("Liet-ke-danh-sach-sinh-vien")]
        public IActionResult ListAll()
        {
            List<Student> students = new List<Student>()
            {
                new Student{Id = 1, Name = "Đại Đạt", Age = 19, Gender = true, ImgUrl = "https://i.imgur.com/4K0v1rY.jpg", Des = "Đại Đạt là một sinh viên năm nhất"},

                new Student{Id = 2, Name = "Đại Đạt", Age = 19, Gender = true, ImgUrl = "https://i.imgur.com/4K0v1rY.jpg", Des = "Đại Đạt là một sinh viên năm nhất"},
                new Student{Id = 3, Name = "Đại Đạt", Age = 19, Gender = true, ImgUrl = "https://i.imgur.com/4K0v1rY.jpg", Des = "Đại Đạt là một sinh viên năm nhất"},
                new Student{Id = 4, Name = "Đại Đạt", Age = 19, Gender = true, ImgUrl = "https://i.imgur.com/4K0v1rY.jpg", Des = "Đại Đạt là một sinh viên năm nhất"},
                new Student{Id = 5, Name = "Đại Đạt", Age = 19, Gender = true, ImgUrl = "https://i.imgur.com/4K0v1rY.jpg", Des = "Đại Đạt là một sinh viên năm nhất"},
                new Student{Id = 6, Name = "Đại Đạt", Age = 19, Gender = true, ImgUrl = "https://i.imgur.com/4K0v1rY.jpg", Des = "Đại Đạt là một sinh viên năm nhất"},
            };
            return View(students);
        }
        [Route("Student/Index")]
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "Welcome to Student page",
                ContentType = "text/plain",
            };
        }
        [Route("File/Download-File")]
        public FileResult IndexFile()
        {
            return File("/s2.pdf","application/pdf");
        }
        [Route("Student/List")]
        public IActionResult ListOnlyOne()
        {
            if(!Request.Query.ContainsKey("id"))
            {
                return BadRequest("Student ID is not provided");
            }
            int id = Convert.ToInt32(Request.Query["id"]);
            if (id < 1 || id > 100)
            {
                return NotFound("Student ID not found");
            }
            return Content("thong tin sinh vien co id = " + id, "text/html");
        }
        [Route("Student/Only-Student")]
        public IActionResult ListOnlyStudent([FromQuery] int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("Student ID is not provided");
            }
            else
            {
                return Content($"thong tin sinh vien {id}");
            }
        }
        [Route("Student/Edit-Student")]
        public IActionResult EditStudent()
        {
            return LocalRedirect("~/Home/Index");
        }
        public string AddStudent()
        {
            return "Thêm sinh viên mới";
        }
        public string DeleteStudent()
        {
            return "Xóa sinh viên có id cụ thể";
        }
    }
}
