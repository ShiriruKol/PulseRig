using PulseRig.BuissnesLayer;
using PulseRig.DataLayer.Entityes;
using PulseRig.PresentationLayer.Models;

namespace PulseRig.PresentationLayer.Services;

public class EquipmentService
{
    private DataManager dataManager;
    public EquipmentService(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public EquipmentViewModel EquipmentDBModelToView(int equipmentId)
    {
        Equipment equipment = dataManager.Equipments.GetEquipmentById(equipmentId);
        var _model = new EquipmentViewModel()
        {
            Equipment = equipment,
            GroupName = dataManager.Groups.GetGroupById(equipment.GroupId).Name
        };

        return _model;
    }

    public EquipmentEditViewModel GetSongEditModel(int Id)
    {
        var _dbModel = dataManager.Equipments.GetEquipmentById(Id);
        var _editModel = new EquipmentEditViewModel()
        {
            Id = _dbModel.Id = _dbModel.Id,
            Name = _dbModel.Name,
            FactoryNumber = _dbModel.FactoryNumber,
            Type = _dbModel.Type,
        };
        return _editModel;
    }

    public EquipmentViewModel SaveSongEditModelToDb(EquipmentEditViewModel editModel)
    {
        Equipment equipment;
        if (editModel.Id != 0)
        {
            equipment = dataManager.Equipments.GetEquipmentById(editModel.Id);
        }
        else
        {
            equipment = new Equipment();
        }
        equipment.Name = editModel.Name;
        equipment.FactoryNumber = editModel.FactoryNumber;
        equipment.Type = editModel.Type;
        equipment.GroupId = editModel.Groupid;
        dataManager.Equipments.SaveEquipment(equipment);
        return EquipmentDBModelToView(equipment.Id);
    }

    public void DeleteSong(int id)
    {
        Equipment equipment;
        if (id != 0)
        {
            equipment = dataManager.Equipments.GetEquipmentById(id);
        }
        else
        {
            equipment = new Equipment();
        }
        dataManager.Equipments.DeleteEquipment(equipment);
    }

    public EquipmentEditViewModel CreateNewSongEditModel(int groupId)
    {
        return new EquipmentEditViewModel() { Groupid = groupId };
    }
}
