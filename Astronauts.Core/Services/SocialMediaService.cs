using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace Astronauts.Core.Services;

public class SocialMediaService : ISocialMediaService
{
    private readonly IUnitOfWork _unitOfWork;
    //private readonly ISocialMediaRepository _socialMediaRepository;

    public SocialMediaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<SocialMedia> GetSocialMediaByAstronaut(int id)
    {
        var socialMedia =  _unitOfWork.SocialMediaRepository.GetSocialMediaByAstronaut(id);
        var socialMediaList = socialMedia.Result;
        return socialMediaList;
    }

    public async Task PostSocialMedia(SocialMedia socialMedia)
    {
        await _unitOfWork.SocialMediaRepository.Post(socialMedia);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> UpdateSocialMedia(SocialMedia socialMedia)
    {
        var existingRecord = await _unitOfWork.SocialMediaRepository.GetById(socialMedia.Id);
        existingRecord.Description = socialMedia.Description;
        existingRecord.Link = socialMedia.Link;

        _unitOfWork.SocialMediaRepository.Update(existingRecord);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteSocialMedia(int id)
    {
        await _unitOfWork.SocialMediaRepository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

}
