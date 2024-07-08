using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.Interfaces.CoreApplication;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentController : Controller
    {
       // private readonly HttpClient _httpClient; 
        public readonly IAgentApplication _agentApplication;
        public readonly IAgentPriceApplication _agentPriceApplication;
        public AgentController(IAgentApplication agentApplication, IAgentPriceApplication agentPriceApplication)
        {
            _agentApplication = agentApplication;
            _agentPriceApplication = agentPriceApplication; 
           
        }
       
        [HttpPost]
        [Route("copilot")]
        public async Task<ActionResult> ChatGpt(string query)
        {
            var _httpClient = new HttpClient();
            string apiKey = "458196fd1b2c4b91aed6fbb231cdcba7";
            string endpoint = $"https://api.bing.microsoft.com/v7.0/search?q={Uri.EscapeDataString(query)}";

            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return Ok(jsonResponse);
            }
            else
            {
                throw new Exception("Failed to fetch results from Bing Search API");
            }
        }

        [HttpPost()]
        [Route("addOrUpdate")]
        public async Task<ActionResult> AddOrUpdateAgent(AddOrUpdateAgentResponseDto request)
        {
            return Ok(await _agentApplication.AddOrUpdateAgent(request));
        }
        [HttpGet()]
        [Route("Get")]
        public async Task<ActionResult> GetAgents(string? code, string? name, string? state)
        {
            code ??= string.Empty;
            name ??= string.Empty;
            state ??= string.Empty;
            return Ok(await _agentApplication.GetListAgentAsync(code,name,state));
        }
        [HttpGet()]
        [Route("GetById")]
        public async Task<ActionResult> GetAgentById(int idAgent)
        {
            return Ok(await _agentApplication.GetAgentById(idAgent));
        }
        [HttpPost()]
        [Route("addOrUpdatePrice")]
        public async Task<ActionResult> AddOrUpdateAgentPrice(AddOrUpdateAgentPriceRequestDto request)
        {
            return Ok(await _agentPriceApplication.AddOrUpdateAgentPrice(request));
        }
        [HttpGet()]
        [Route("GetPricesById")]
        public async Task<ActionResult> GetPricesById(int idAgent)
        {
            return Ok(await _agentPriceApplication.GetPricesById(idAgent));
        }
        [HttpGet()]
        [Route("GetPriceById")]
        public async Task<ActionResult> GetPriceById(int id)
        {
            return Ok(await _agentPriceApplication.GetPriceById(id));
        }
        [HttpPost()]
        [Route("deletePrice")]
        public async Task<ActionResult> deletePrice(int id)
        {
            return Ok(await _agentPriceApplication.DeleteAgentPrice(id));
        }
        [HttpPost]
        [Route("blobToBase64")]
        public async Task<ActionResult<string>> ConvertBlobToBase64([FromBody] byte[] blob)
        {
            try
            {
                // Verifica si el blob es nulo o está vacío
                if (blob == null || blob.Length == 0)
                {
                    return BadRequest("El blob proporcionado es nulo o está vacío.");
                }

                // Convierte el blob a base64
                string base64String = Convert.ToBase64String(blob);

                // Devuelve la cadena base64 como respuesta
                return Ok(base64String);
            }
            catch (Exception ex)
            {
                // Maneja cualquier error y devuelve un mensaje de error
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
