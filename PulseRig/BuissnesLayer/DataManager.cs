using PulseRig.BuissnesLayer.Interfaces;

namespace PulseRig.BuissnesLayer;

public class DataManager
{
    private IStationRepository _stationRepository;
    private IGroupRepository _groupRepository;
    private IEquipmentRepository _equipmentRepository;

    public DataManager(IStationRepository stationRepository, IGroupRepository groupRepository, IEquipmentRepository equipmentRepository)
    {
        _stationRepository = stationRepository;
        _groupRepository = groupRepository;
        _equipmentRepository = equipmentRepository;
    }

    public IStationRepository Stations { get { return _stationRepository; } }
    public IGroupRepository Groups { get { return _groupRepository; } }
    public IEquipmentRepository Equipments { get { return _equipmentRepository; } }
}
