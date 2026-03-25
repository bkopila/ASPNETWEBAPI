// // // Controllers/InfoController.cs
// // using Microsoft.AspNetCore.Mvc;
// // using Microsoft.Extensions.Options;

// // [ApiController]
// // [Route("api/[controller]")]
// // public class InfoController : ControllerBase
// // {
// //     private readonly MyInfoOptions _myInfo;

// //     // Inject IOptions<T> for the MyInfo configuration
// //     public InfoController(IOptions<MyInfoOptions> options)
// //     {
// //         _myInfo = options.Value;
// //     }

// //     [HttpGet]
// //     public IActionResult GetInfo()
// //     {
// //         // Return all info from configuration
// //         return Ok(new
// //         {
// //             Name = _myInfo.Name,
// //             Age = _myInfo.Age,
// //             Address = _myInfo.Address,
// //             IsStudent = _myInfo.IsStudent,
// //             Email = _myInfo.Email,
// //             DemoMethod = "IOptions"
// //         });
// //     }

// //     [HttpGet("name")]
// //     public IActionResult GetName()
// //     {
// //         return Ok(new { Name = _myInfo.Name });
// //     }

// //     [HttpGet("age")]
// //     public IActionResult GetAge()
// //     {
// //         return Ok(new { Age = _myInfo.Age });
// //     }

// //     [HttpGet("address")]
// //     public IActionResult GetAddress()
// //     {
// //         return Ok(new { Address = _myInfo.Address });
// //     }

// //     [HttpGet("student-status")]
// //     public IActionResult GetStudentStatus()
// //     {
// //         return Ok(new { IsStudent = _myInfo.IsStudent });
// //     }

// //     [HttpGet("email")]
// //     public IActionResult GetEmail()
// //     {
// //         return Ok(new { Email = _myInfo.Email });
// //     }
// // }

// // Controllers/InfoControllerReloadable.cs
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;
// using YourApp.Models;

// [ApiController]
// [Route("api/[controller]")]
// public class InfoControllerReloadable : ControllerBase
// {
//     private readonly MyInfoOptions _myInfo;

//     // Use IOptionsSnapshot for reloadable configuration
//     public InfoControllerReloadable(IOptionsSnapshot<MyInfoOptions> options)
//     {
//         _myInfo = options.Value;
//     }

//     [HttpGet]
//     public IActionResult GetInfo()
//     {
//         return Ok(new
//         {
//             Name = _myInfo.Name,
//             Age = _myInfo.Age,
//             Address = _myInfo.Address,
//             IsStudent = _myInfo.IsStudent,
//             Email = _myInfo.Email,
//             DemoMethod = "IOptionsSnapshot (reloadable)"
//         });
//     }
// }


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/[controller]")]
public class InfoController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public InfoController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetInfo()
    {
        string name = _configuration["MyInfo:Name"];
        string age = _configuration["MyInfo:Age"];
        string address = _configuration["MyInfo:Address"];
        string isStudent = _configuration["MyInfo:IsStudent"];
        string email = _configuration["MyInfo:Email"];
        string phone = _configuration["MyInfo:phone"];
        string demoMethod = "IConfiguration";

        return Ok(new
        {
            Name = name,
            Age = age,
            Address = address,
            IsStudent = isStudent,
            Email = email,
            Phone = phone,

            Method = demoMethod
        });
    }
}