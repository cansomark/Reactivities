using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Activity;

namespace API.Controllers
{
    public class ActivityController:BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(){
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>>GetActivities(Guid id){
            return await Mediator.Send(new Details.Query{Id=id});
        }

        [HttpPost]
        public async Task<IActionResult>AddData(Activity activity){
            return Ok(await Mediator.Send(new AddDetails.Command{Activity=activity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>EditActivity(Guid id, Activity activity) {
            activity.Id=id;
            return Ok(await Mediator.Send(new EditDetails.Command{Activity=activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProfile(Guid id){
            return Ok(await Mediator.Send(new Delete.Command{Id=id}));
        }
    }
}