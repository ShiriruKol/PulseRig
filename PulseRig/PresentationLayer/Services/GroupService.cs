using PulseRig.BuissnesLayer;
using PulseRig.DataLayer.Entityes;
using PulseRig.PresentationLayer.Models;

namespace PulseRig.PresentationLayer.Services;

public class GroupService
{
    private DataManager _dataManager;
    private EquipmentService _equipmentService;
    public GroupService(DataManager dataManager)
    {
        this._dataManager = dataManager;
        _equipmentService = new EquipmentService(dataManager);
    }

    public List<GroupViewModel> GetGroupsList()
    {
        var _dirs = _dataManager.Groups.GetAllGroups(true);
        List<GroupViewModel> _modelsList = new List<GroupViewModel>();
        foreach (var item in _dirs)
        {
            _modelsList.Add(GroupDBToViewModelById(item.Id));
        }
        return _modelsList;
    }

    public GroupViewModel GroupDBToViewModelById(int grouId)
    {
        var _directory = _dataManager.Groups.GetGroupById(grouId, true);

        List<EquipmentViewModel> _materialsViewModelList = new List<EquipmentViewModel>();
        foreach (var item in _directory.Equipments)
        {
            _materialsViewModelList.Add(_equipmentService.EquipmentDBModelToView(item.Id));
        }
        return new GroupViewModel() { Group = _directory, Equipments = _materialsViewModelList };
    }

    public GroupEditViewModel GetGroupEditModel(int directoryid = 0)
    {
        if (directoryid != 0)
        {
            var _dirDB = _dataManager.Groups.GetGroupById(directoryid);
            var _dirEditModel = new GroupEditViewModel()
            {
                Id = _dirDB.Id,
                Name = _dirDB.Name,
                Description = _dirDB.Description,
            };
            return _dirEditModel;
        }
        else { return new GroupEditViewModel() { }; }
    }

    public GroupViewModel SaveAlbumEditModelToDb(GroupEditViewModel groupEditModel)
    {
        Group _groupDbModel;
        Station _statDbMocel;
        if (groupEditModel.Id != 0)
        {
            _groupDbModel = _dataManager.Groups.GetGroupById(groupEditModel.Id);
            _statDbMocel = _dataManager.Stations.GetStationById(groupEditModel.StationId);
        }
        else
        {
            _groupDbModel = new Group();
            _statDbMocel = _dataManager.Stations.GetStationById(groupEditModel.StationId);
        }
        _groupDbModel.Name = groupEditModel.Name;
        _groupDbModel.Description = groupEditModel.Description;
        _groupDbModel.Station = _statDbMocel;

        _dataManager.Groups.SaveGroup(_groupDbModel);

        return GroupDBToViewModelById(_groupDbModel.Id);
    }

    public void DeleteGroup(int id)
    {
        Group _directoryDbModel;
        if (id != 0)
        {
            _directoryDbModel = _dataManager.Groups.GetGroupById(id);
        }
        else
        {
            _directoryDbModel = new Group();
        }
        _dataManager.Groups.DeleteGroup(_directoryDbModel);
    }

    public GroupEditViewModel CreateNewAlbumEditModel(int id)
    {
        return new GroupEditViewModel() { };
    }

    public GroupEditViewModel CreateNewAlbumEditModel()
    {
        return new GroupEditViewModel() { };
    }
}
