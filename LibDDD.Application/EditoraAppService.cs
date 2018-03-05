using LibDDD.Application.Interface;
using LibDDD.Domain.Entities;
using LibDDD.Domain.Interface.Services;

namespace LibDDD.Application
{
    public class EditoraAppService : AppServiceBase<Editora>, IEditoraAppService
    {
        private readonly IEditoraService _editoraService;
        public EditoraAppService(IEditoraService editoraService)
            : base(editoraService)
        {
            _editoraService = editoraService;
        }
    }
}
