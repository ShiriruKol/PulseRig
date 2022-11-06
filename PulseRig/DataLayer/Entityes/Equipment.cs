namespace PulseRig.DataLayer.Entityes;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string FactoryNumber { get; set; }
    public int GroupId { get; set; } //Внешний ключ
    public Group Group { get; set; } //Навигационное свойство
}
