using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly DataContext _context;
        public VehicleController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("registerUser")]
        public async Task<ActionResult<User>> RegisterUser(User user)
        {
            var userObj = _context.Users.FirstOrDefault(x => x.FirstName == user.FirstName
            && x.LastName == user.LastName);
            if (userObj != null)
            {
                return BadRequest("This user has been already registerd!!");
            }
            else
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
        }

        [HttpPost("registerVehicle")]
        public async Task<ActionResult<VehicleDetail>> RegisterVehicle(VehicleDto vehicleDto)
        {
            var vehicleDetail = _context.Vehicles.FirstOrDefault(x => x.VehicleNo == vehicleDto.VehicleNo
            && x.IsActive == 1);
            if (vehicleDetail != null)
            {
                return BadRequest("This vehicle has been already registerd!!");
            }
            else
            {
                var vehicle = new VehicleDetail()
                {
                    VehicleNo = vehicleDto.VehicleNo,
                    UserId = vehicleDto.UserId,
                    IsActive = 1
                };
                var user = _context.Users.FirstOrDefault(x => x.Id == vehicle.UserId);
                if (user != null)
                {
                    //vehicle.User = user;
                    _context.Vehicles.Add(vehicle);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return Unauthorized("Invalid user");
                }
                return vehicle;
            }

        }

        [HttpPost("UpdateVehicleLocation")]
        public async Task<ActionResult<VehiclePosition>> UpdateVehicleLocation(VehicleLocationDto vehicleLocationDto)
        {
            var vehiclePosition = new VehiclePosition()
            {
                VehicleNo = vehicleLocationDto.VehicleNo,
                TimeStamp = vehicleLocationDto.TimeStamp,
                Location = vehicleLocationDto.Location
            };

            var vehicle = _context.Vehicles.FirstOrDefault(x => x.VehicleNo == vehiclePosition.VehicleNo && x.UserId == vehicleLocationDto.UserId && x.IsActive == 1);
            if (vehicle != null)
            {
                vehicle.User = _context.Users.FirstOrDefault(x => x.Id == vehicle.UserId);
                vehiclePosition.VehicleDetail = vehicle;
                _context.VehicleLocations.Add(vehiclePosition);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Unauthorized("Invalid user/vehicle");
            }
            return vehiclePosition;
        }

        [HttpGet("GetVehicleCurrentPosition")]
        public async Task<ActionResult<VehiclePosition>> GetVehicleCurrentPosition(VehicleDto vehicleDto)
        {
            var vehicleLocation = _context.VehicleLocations.FirstOrDefault(x => x.VehicleNo == vehicleDto.VehicleNo
                && x.VehicleDetail.UserId == vehicleDto.UserId
                && x.TimeStamp == DateTime.Now);
            if (vehicleLocation != null)
            {
                return vehicleLocation;
            }
            else
            {
                return Unauthorized("Invalid user/vehicle");
            }
        }

        [HttpGet("GetVehiclePositionAt")]
        public async Task<ActionResult<VehiclePosition>> GetVehiclePositionAt(VehicleLogDto vehicleLogDto)
        {
            return await _context.VehicleLocations.FirstOrDefaultAsync(x => x.VehicleNo == vehicleLogDto.VehicleNo && x.TimeStamp == vehicleLogDto.TimeStamp);
        }
    }
}