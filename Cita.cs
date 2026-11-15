namespace Tarea_4
{
    public class Cita
    {
        public Cita() { }
        public Cita(int id, DateTime dateandtime, string state, Doctor relateddoctor, Paciente relatedpatient)
        {
            Id = id;
            Dateandtime = dateandtime;
            State = state;
            RelatedDoctor = relateddoctor;
            RelatedPatient = relatedpatient;
        }
        public int Id { get; set; }
        public DateTime Dateandtime { get; set; }
        public string State { get; set; }
        public Doctor RelatedDoctor { get; set; }
        public Paciente RelatedPatient { get; set; }
        public override string ToString()
        {
            return $"{Id,-4}{RelatedPatient.Name,-30}{RelatedDoctor.Name,-30}{Dateandtime,-30}{State,-15}";
        }
        public static void ShowAll(List<Cita> citas)
        {
            Console.WriteLine("A continuación se mostrarán las citas listadas:");
            Console.WriteLine($"{"ID",-4}{"Paciente",-30}{"Doctor",-30}{"Fecha y hora",-30}{"Estado",-15}");
            foreach (Cita c in citas)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public static void ShowOne(List<Cita> appointments, int selector)
        {
            Cita c = appointments.FirstOrDefault(c => c.Id == selector);
            Console.WriteLine($"{"ID",-4}{"Paciente",-30}{"Doctor",-30}{"Fecha y hora",-30}{"Estado",-15}");
            Console.WriteLine(c.ToString());
        }

        public static void ChangeState(Cita appointment)
        {
            appointment.State = "Cancelada";
        }
    }
}
