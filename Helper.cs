namespace Tarea_4
{
    public static class Helper
    {
        public static void AddPaciente(List<Paciente> patients)
        {
            bool mistakes = false;
            string name = " ";
            long document = 0;
            long phonenumber = 0;
            string email = " ";
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            DateOnly date = default;
            int year = 0;
            int month = 0;
            int day = 0;
            Console.WriteLine("Introduzca el nombre del paciente");
            name = Console.ReadLine();
            do
            {
                mistakes = false;
                try
                {
                    Console.WriteLine("Ingrese la fecha de nacimiento del paciente");
                    Console.WriteLine("Mes de nacimiento:");
                    month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Día de nacimiento:");
                    day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Año de nacimiento:");
                    year = int.Parse(Console.ReadLine());
                    Console.WriteLine("La fecha digitada fue: " + day + "/" + month + "/" + year);
                    date = new DateOnly(year, month, day);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Utilice solo números para las fechas");
                    mistakes = true;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("La fecha introducida no es valida");
                    mistakes = true;
                }
                if (!mistakes && date > today)
                {
                    Console.WriteLine("No se pueden colocar fechas de nacimiento en fechas que aún no han pasado");
                    mistakes = true;
                }
            } while (mistakes);
            do
            {
                mistakes = false;
                try
                {
                    Console.WriteLine("Ingrese el numero de telefono del paciente:");
                    phonenumber = long.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato, use solamente numeros en el telefono");
                    mistakes = true;
                }
            } while (mistakes);
            if (patients.Any(p => p.Phonenumber == phonenumber))
            {
                Console.WriteLine("Ya existe un paciente registrado con este telefono");
                return;
            }
            Console.WriteLine("Ingrese el correo electronico del paciente");
            email = Console.ReadLine();
            if (patients.Any(p => p.Email == email))
            {
                Console.WriteLine("Ya existe un paciente registrado con esta direccion de correo");
                return;
            }
            do
            {
                mistakes = false;
                try
                {
                    Console.WriteLine("Ingrese el numero de documento de identidad del paciente:");
                    document = long.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato, utilice solamente numeros para digitar el Numero de identidad del paciente");
                    mistakes = true;
                }
            } while (mistakes);
            if (patients.Any(p => p.Document == document))
            {
                Console.WriteLine("Ya existe un paciente registrado con este documento de identidad");
                return;
            }
            Paciente patient = new Paciente();
            patient.Name = name;
            patient.Birthday = date;
            patient.Document = document;
            patient.Phonenumber = phonenumber;
            patient.Email = email;

            patients.Add(patient);
        }
        public static void AddDoctor(List<Doctor> doctors)
        {
            bool mistakes = false;
            string name = " ";
            long document = 0;
            long phonenumber = 0;
            string email = " ";
            string area = " ";
            Console.WriteLine("Introduzca el nombre del doctor");
            name = Console.ReadLine();
            Console.WriteLine("Introduzca la especialidad del doctor");
            area = Console.ReadLine();
            do
            {
                mistakes = false;
                try
                {
                    Console.WriteLine("Ingrese el numero de telefono del doctor ");
                    phonenumber = long.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato, use solamente numeros en el telefono");
                    mistakes = true;
                }
            } while (mistakes);
            if (doctors.Any(p => p.Phonenumber == phonenumber))
            {
                Console.WriteLine("Ya existe un doctor registrado con este telefono");
                return;
            }
            Console.WriteLine("Ingrese el correo electronico del doctor: ");
            email = Console.ReadLine();
            if (doctors.Any(p => p.Email == email))
            {
                Console.WriteLine("Ya existe un doctor registrado con este correo electronico");
                return;
            }
            do
            {
                mistakes = false;
                try
                {
                    Console.WriteLine("Ingrese la cedula profesional del doctor: ");
                    document = long.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato, utilice solamente numeros para digitar la cedula profesional del doctor");
                    mistakes = true;
                }
            } while (mistakes);
            if (doctors.Any(p => p.Document == document))
            {
                Console.WriteLine("Ya existe un doctor registrado con este documento");
                return;
            }
            Doctor doctor = new Doctor();
            doctor.Name = name;
            doctor.Area = area;
            doctor.Phonenumber = phonenumber;
            doctor.Email = email;
            doctor.Document = document;
            doctors.Add(doctor);
        }
        public static void AddCita(List<Cita> appointments, List<Paciente> patients, List<Doctor> doctors)
        {
            if (doctors.Count == 0 || patients.Count == 0)
            {
                if (doctors.Count == 0 && patients.Count == 0)
                {
                    Console.WriteLine("No hay pacientes ni doctores inscritos en el sistema, así que no es posible realizar una cita");
                }
                else if (doctors.Count == 0)
                {
                    Console.WriteLine("No hay doctores inscritos en el sistema, así que no es posible realizar una cita");
                }
                else
                {
                    Console.WriteLine("No hay pacientes inscritos en el sistema, así que no es posible realizar una cita");
                }
                return;
            }
            bool mistakes = false;
            int selector = 0;
            int year = 0;
            int month = 0;
            int day = 0;
            int hour = 0;
            DateTime limit = DateTime.Now;
            DateTime date = default;
            string state = "Pendiente";
            Doctor relateddoctor = null;
            Paciente relatedpatient = null;
            do
            {
                mistakes = false;
                Paciente.ShowAll(patients);
                try
                {
                    Console.WriteLine("Digite el id del paciente que solicitó la cita");
                    selector = int.Parse(Console.ReadLine());
                    relatedpatient = patients.FirstOrDefault(p => p.Id == selector);
                    if (relatedpatient == null)
                    {
                        Console.WriteLine("La ID introducida es inexistente");
                        mistakes = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Solo use números para indicar el ID");
                    mistakes = true;
                }
            } while (mistakes);
            do
            {
                mistakes = false;
                Doctor.ShowAll(doctors);
                try
                {
                    Console.WriteLine("Digite el id del doctor que atenderá la cita");
                    selector = int.Parse(Console.ReadLine());
                    relateddoctor = doctors.FirstOrDefault(p => p.Id == selector);
                    if (relateddoctor == null)
                    {
                        Console.WriteLine("La ID introducida es inexistente");
                        mistakes = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Solo use números para indicar el ID");
                    mistakes = true;
                }
            } while (mistakes);
            bool exitdate = true;
            do
            {
                exitdate = true;
                Console.WriteLine("Introduzca la fecha de la cita\nNota: Solo se pueden registrar citas en el año actual");
                year = limit.Year;
                do
                {
                    do
                    {
                        try
                        {
                            mistakes = false;
                            Console.WriteLine("Introduzca el mes donde quiere agendar la cita");
                            month = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error al ingresar el mes, por favor recuerde introducir un número del 1-12");
                            mistakes = true;
                        }
                    } while (mistakes);
                    if (month < limit.Month)
                    {
                        Console.WriteLine("El mes introducido ya ha pasado en el presente año");
                        mistakes = true;
                    }
                    if (month > 12 || month < 1)
                    {
                        Console.WriteLine("El mes introducido es inexistente");
                        mistakes = true;
                    }
                } while (mistakes);
                do
                {
                    try
                    {
                        mistakes = false;
                        Console.WriteLine("Introduzca el día donde quiere agendar la cita");
                        day = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error al ingresar el día, por favor solo introducir números");
                        mistakes = true;
                    }
                    if (day < limit.Day && limit.Month == month)
                    {
                        Console.WriteLine("El día introducido ya ha pasado en el presente mes");
                        mistakes = true;
                    }
                    if ((day < 1) || (day > 31) || (day > 30 && month is 2 or 4 or 6 or 9 or 11) || (day == 30 && month == 2) || (day == 29 && month == 2 && !((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)))
                    {
                        Console.WriteLine("El día no forma parte del calendario");
                        mistakes = true;
                    }
                } while (mistakes);
                do
                {
                    try
                    {
                        mistakes = false;
                        Console.WriteLine("Introduzca la hora a la que desea agendar la cita en formato de 24 horas");
                        hour = int.Parse(Console.ReadLine());
                        if (hour > 23 || hour < 0)
                        {
                            Console.WriteLine("Solo se pueden usar los numeros del 1-23");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Solo se pueden usar numeros enteros del 1-23");
                        mistakes = true;
                    }
                } while (hour < 0 || hour > 23 || mistakes);

                date = new DateTime(year, month, day, hour, 0, 0);

                if (date <= DateTime.Now)
                {
                    Console.WriteLine("La fecha y hora deben ser posteriores al momento actual, intente de nuevo.");
                    exitdate = false;
                }
                else
                {

                    if ((appointments.Any(c => c.Dateandtime == date && c.RelatedDoctor == relateddoctor && c.State == "Pendiente")))
                    {
                        Console.WriteLine("El doctor ya tiene una cita a la fecha y hora asignada, por favor, seleccione otra fecha y hora para su cita.");
                        exitdate = false;
                    }
                    if ((appointments.Any(c => c.Dateandtime == date && c.RelatedPatient == relatedpatient && c.State == "Pendiente")))
                    {
                        Console.WriteLine("El paciente ya tiene una cita a la fecha y hora asignada, por favor, seleccione otra fecha y hora para su cita.");
                        exitdate = false;
                    }

                }
            } while (exitdate == false);
            Cita appointment = new Cita();
            appointment.RelatedDoctor = relateddoctor;
            appointment.RelatedPatient = relatedpatient;
            appointment.State = state;
            appointment.Dateandtime = date;
            appointments.Add(appointment);
        }
        public static void EditCita(List<Cita> appointments, List<Doctor> doctors)
        {
            bool mistakes = false;
            int selector = 0;
            if (appointments.Count == 0 || !(appointments.Any(c => c.State == "Pendiente")))
            {
                Console.WriteLine("No hay ninguna cita pendiente para editar");
                return;
            }
            Cita.ShowAll(appointments);
            do
            {
                mistakes = false;
                try
                {
                    Console.WriteLine("Introduzca el ID de la cita que desea modificar");
                    selector = int.Parse(Console.ReadLine());
                    if (!(appointments.Any(c => c.Id == selector)))
                    {
                        Console.WriteLine("La ID digitada no existe");
                        mistakes = true;
                    }
                    if ((appointments.Any(c => c.Id == selector && c.State == "Cancelada")))
                    {
                        Console.WriteLine("La ID digitada pertenece a una cita cancelada");
                        mistakes = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("El ID debe introducirse como un numero entero");
                    mistakes = true;
                }
            } while (mistakes);
            Console.WriteLine("Información de la cita: ");
            Cita.ShowOne(appointments, selector);
            Console.WriteLine("¿Desea cambiar la fecha y/o hora de la cita o el doctor de la misma?");
            int Changeoption = 0;
            do
            {
                mistakes = false;
                try
                {
                    Console.WriteLine("1.Retrasar fecha de la cita.\n2.Cambiar de doctor");
                    Changeoption = int.Parse(Console.ReadLine());
                    if (!(Changeoption is 1 or 2))
                    {
                        Console.WriteLine("Solo introduzca '1' o '2'");
                        mistakes = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Solo introduzca '1' o '2'");
                    mistakes = true;
                }
            } while (mistakes);
            Cita appointmentedit = appointments.FirstOrDefault(c => c.Id == selector);
            switch (Changeoption)
            {
                case 1:
                    {
                        ChangeDate(appointments, appointmentedit);
                        break;
                    }
                case 2:
                    {
                        ChangeDoctor(appointments, appointmentedit, doctors);
                        break;
                    }
            }
        }
        public static void ChangeDate(List<Cita> appointments, Cita appointmentedit)
        {
            bool exitchange;
            bool mistakes;
            int month = 0;
            int day = 0;
            int hour = 0;
            Cita datetest = new Cita();
            Console.WriteLine("La fecha actual de la cita es: " + appointmentedit.Dateandtime);
            do
            {
                exitchange = true;
                do
                {
                    mistakes = false;
                    try
                    {
                        Console.WriteLine("Introduzca el mes donde quiere re-agendar la cita");
                        month = int.Parse(Console.ReadLine());
                        if (month < appointmentedit.Dateandtime.Month)
                        {
                            Console.WriteLine("La fecha no puede actualizarse a un mes anterior, debe ser el mismo mes o uno posterior");
                            mistakes = true;
                        }
                        if (month >= 13)
                        {
                            Console.WriteLine("No existe un mes " + month.ToString());
                            mistakes = true;
                        }
                        if (month <= 0)
                        {
                            Console.WriteLine("No existe un mes" + month.ToString());
                            mistakes = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error al ingresar el mes, por favor recuerde introducir un número del 1-12");
                        mistakes = true;
                    }
                } while (mistakes);
                do
                {
                    mistakes = false;
                    try
                    {
                        Console.WriteLine("Introduzca el día donde quiere re-agendar la cita");
                        day = int.Parse(Console.ReadLine());
                        if (day < appointmentedit.Dateandtime.Day && month == appointmentedit.Dateandtime.Month)
                        {
                            Console.WriteLine("El día no puede ser anterior a la fecha agendada anteriormente: " + appointmentedit.Dateandtime.Day + "/" + appointmentedit.Dateandtime.Month + "/" + appointmentedit.Dateandtime.Year);
                            mistakes = true;
                        }
                        if ((day < 1) || (day > 31) || (day > 30 && month is 2 or 4 or 6 or 9 or 11) || (day == 30 && month == 2) || (day == 29 && month == 2 && !((appointmentedit.Dateandtime.Year % 4 == 0 && appointmentedit.Dateandtime.Year % 100 != 0) || appointmentedit.Dateandtime.Year % 400 == 0)))
                        {
                            Console.WriteLine("El día no forma parte del calendario");
                            mistakes = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error al ingresar el día, por favor recuerde introducir numeros enteros");
                        mistakes = true;
                    }
                } while (mistakes);
                do
                {
                    mistakes = false;
                    try
                    {
                        Console.WriteLine("Introduzca la hora a la que desea agendar la cita en formato de 24 horas");
                        hour = int.Parse(Console.ReadLine());
                        if (hour < 0 || hour > 23)
                        {
                            Console.WriteLine("La hora ingresada es invalida");
                            mistakes = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error al ingresar la hora, use solo numeros enteros");
                        mistakes = true;
                    }
                } while (mistakes);
                datetest.Dateandtime = new DateTime(appointmentedit.Dateandtime.Year, month, day, hour, 0, 0);
                if ((appointments.Any(c => c.Id != appointmentedit.Id && c.Dateandtime == datetest.Dateandtime && c.RelatedDoctor == appointmentedit.RelatedDoctor && c.State == "Pendiente")))
                {
                    Console.WriteLine("El doctor ya tiene una cita a la fecha y hora asignada, por favor, seleccione otra fecha y hora para su cita.");
                    exitchange = false;
                }
                if ((appointments.Any(c => c.Id != appointmentedit.Id && c.Dateandtime == datetest.Dateandtime && c.RelatedPatient == appointmentedit.RelatedPatient && c.State == "Pendiente")))
                {
                    Console.WriteLine("El paciente ya tiene una cita a la fecha y hora asignada, por favor, seleccione otra fecha y hora para su cita.");
                    exitchange = false;
                }
            } while (exitchange == false);
            appointmentedit.Dateandtime = datetest.Dateandtime;
        }
        public static void ChangeDoctor(List<Cita> appointments, Cita appointmentedit, List<Doctor> doctors)
        {
            Console.WriteLine("El/la doctor/a que atenderá la cita actualmente es: " + appointmentedit.RelatedDoctor.Name);
            Doctor.ShowAll(doctors);

            int newid = 0;
            Doctor newdoctor = null;
            bool mistakes = false;

            do
            {
                mistakes = false;

                do
                {
                    try
                    {
                        mistakes = false;
                        Console.WriteLine("Digite el id del nuevo doctor que atenderá la cita");
                        newid = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Solo use números para indicar el ID");
                        mistakes = true;
                    }
                } while (mistakes);

                newdoctor = doctors.FirstOrDefault(d => d.Id == newid);

                if (newdoctor == null)
                {
                    Console.WriteLine("El ID no pertenece a ningún doctor");
                    mistakes = true;
                }
                else if (appointments.Any(c => c.Id != appointmentedit.Id && c.Dateandtime == appointmentedit.Dateandtime && c.RelatedDoctor == newdoctor && c.State == "Pendiente"))
                {
                    Console.WriteLine("El doctor ya tiene una cita a esa fecha y hora, por favor seleccione otro doctor.");
                    mistakes = true;
                }
            } while (mistakes);

            appointmentedit.RelatedDoctor = newdoctor;
        }
        public static void CancelCita(List<Cita> appointments)
        {
            bool mistakes = false;
            int selector = 0;
            if (appointments.Count == 0 || !(appointments.Any(c => c.State == "Pendiente")))
            {
                Console.WriteLine("No hay ninguna cita para cancelar");
                return;
            }
            Cita.ShowAll(appointments);
            do
            {
                mistakes = false;
                try
                {
                    Console.WriteLine("Introduzca el ID de la cita que desea cancelar");
                    selector = int.Parse(Console.ReadLine());
                    if (!(appointments.Any(c => c.Id == selector)) || !(appointments.Any(c => c.Id == selector && c.State == "Pendiente")))
                    {
                        Console.WriteLine("La ID digitada no existe para una cita pendiente");
                        mistakes = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("El ID debe introducirse como un numero entero");
                    mistakes = true;
                }
            } while (mistakes);
            Cita statechange = appointments.FirstOrDefault(c => c.Id == selector);
            Cita.ChangeState(statechange);
        }
        public static void Save(HelperDbContext db, List<Paciente> patients, List<Doctor> doctors, List<Cita> appointments)
        {
            db.Patients.AddRange(patients.Where(p => p.Id == 0));
            db.Doctors.AddRange(doctors.Where(d => d.Id == 0));
            db.Appointments.AddRange(appointments.Where(c => c.Id == 0));
            db.SaveChanges();  
        }
    }
}