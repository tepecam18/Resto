namespace RestoWPF.MVVM.Model
{
    public class DeviceModel 
    {
        public string ID { get; set; } 
        public string? MachineGuid { get; set; }
        public string? MachineName { get; set; }
        public bool IsMain { get; set; }
    }
}