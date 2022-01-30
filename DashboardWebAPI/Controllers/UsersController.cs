using AutoMapper;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DashboardWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ICalculateService _calculateService;

        public UsersController(IMapper mapper, IUserService userService, ICalculateService calculateService)
        {
            _mapper = mapper;
            _userService = userService;
            _calculateService = calculateService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);

            await _userService.CreateUser(userModel);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLifeModel>>> GetUsersLifeModels()
        {
            var userLifeModels = await _calculateService.GetUsersLifeModels();

            return Ok(userLifeModels);
        }

        [Route("rolling_retention")]
        [HttpGet]
        public async Task<ActionResult<double>> GetRollingRetentionSevenDay()
        {
            var rollingRetentionSevenDay = await _calculateService.GetRollingRetentionKDay(7);

            return Ok(rollingRetentionSevenDay);
        }
    }
}
