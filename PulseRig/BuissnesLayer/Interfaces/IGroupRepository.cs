using PulseRig.DataLayer.Entityes;

namespace PulseRig.BuissnesLayer.Interfaces;

public interface IGroupRepository
{
    IEnumerable<Group> GetAllGroups(bool includeequipment = false);
    Group GetGroupById(int grid, bool includeequipment = false);
    void SaveGroup(Group group);
    void DeleteGroup(Group group);
}
