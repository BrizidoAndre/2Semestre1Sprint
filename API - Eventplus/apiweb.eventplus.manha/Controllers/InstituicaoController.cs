using apiweb.eventplus.manha.Interfaces;
using apiweb.eventplus.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.eventplus.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        IInstituicaoRepository _instituicaoRepository;
        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }
    }
}
