using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndExamen1.Data;
using BackEndExamen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using org.mariuszgromada.math.mxparser;
using BackEndExamen1.Data.UnitsOfWork;

namespace BackEndExamen1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CalculadoraController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<Operacion>> Post(Operacion operacion)
        {

            Operacion _result = await _unitOfWork.Calculate(operacion);
            await _unitOfWork.Complete();
            return Ok(_result);

        }


    }
}