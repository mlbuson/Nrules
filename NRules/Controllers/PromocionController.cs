
using Microsoft.AspNetCore.Mvc;

[Route("api/promocion")]
[ApiController]
public class PromocionController : ControllerBase
{
    private readonly ISession _session;

    public PromocionController(ISession session)
    {
        _session = session;
    }

    // GET: api/promocion/validar?dni=12345678&sexo=F
    [HttpGet("validar")]
    public IActionResult ValidarPromocion([FromQuery] string dni, [FromQuery] string sexo)
    {
        var cliente = new Cliente
        {
            DNI = dni,
            Sexo = sexo,
            EsClienteExistente = true // Simular que el cliente es existente
        };

        // Insertar cliente en la sesión de reglas
        _session.Insert(cliente);
        _session.Fire();

        if (cliente.EsAptoPromocion)
        {
            return Ok(new { mensaje = "Cliente apto para la promoción", cliente });
        }
        else
        {
            return BadRequest(new { mensaje = "Cliente no apto para la promoción o error en el proceso", cliente });
        }
    }
}
