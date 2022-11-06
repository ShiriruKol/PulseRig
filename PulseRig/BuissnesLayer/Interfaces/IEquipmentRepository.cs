using PulseRig.DataLayer.Entityes;

namespace PulseRig.BuissnesLayer.Interfaces;

public interface IEquipmentRepository
{
    IEnumerable<Equipment> GetAllEquipments();
    Equipment GetEquipmentById(int eqid);
    void SaveEquipment(Equipment equipment);
    void DeleteEquipment(Equipment equipment);
}
