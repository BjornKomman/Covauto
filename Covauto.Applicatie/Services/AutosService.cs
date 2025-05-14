using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Application.Services;

public class AutosService : IAutosService
{
    private readonly IAutosRepository AutosRepository;

    public AutosService(IAutosRepository autosRepository)
    {
        this.autosRepository = autosRepository;
    }

    public async Task<int> CreateAutoAsync(CreateAuto auto)
    {
        return await autosRepository.CreateAutoAsync(auto);
    }

    public async Task DeleteAutoAsync(int id)
    {
        await autosRepository.DeleteAutoAsync(id);
    }

    public async Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync()
    {
        return await autosRepository.GeefAlleAutosAsync();
    }

    public async Task<FullAuto?> GeefAutoAsync(int id)
    {
        return await autosRepository.GeefAuto(id);
    }

    public async Task UpdateBoekAsync(int id, UpdateAuto auto)
    {
        await autosRepository.UpdateAutoAsync(id, auto);
    }

    public async Task<IEnumerable<AutoListItem>> ZoekAutosAsync(string naam)
    {
        return await autosRepository.ZoekAutosAsync(naam);
    }
}