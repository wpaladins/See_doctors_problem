using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace See_doctors_problem
{
    public partial class See_doctors_problem : Form
    {
        Semaphore sema_wait_patient = new Semaphore(0, 3);
        Semaphore sema_doctor = new Semaphore(3, 3);
        Semaphore mutex = new Semaphore(1,1);

        bool no_created = true;
        int waiting_doctors = 0;
        int chairs = 10;

        public See_doctors_problem()
        {
            InitializeComponent();
        }

        private void See_doctors_problem_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            doctor1.Image = Resource1.wait_patient;
            doctor2.Image = Resource1.wait_patient;
            doctor3.Image = Resource1.wait_patient;
            patient1.Image = null;
            patient2.Image = null;
            patient3.Image = null;
            patient4.Image = null;
            patient5.Image = null;
            patient6.Image = null;
            patient7.Image = null;
            patient8.Image = null;
            patient9.Image = null;
            patient10.Image = null;
        }

        private delegate void dele_doctor1();//delegate方法；
        private delegate void dele_doctor2();
        private delegate void dele_doctor3();
        private delegate void dele_patient();
        private static void by_doctor1()
        {
            return;
        }//被调用方法；
        private static void by_doctor2()
        {
            return;
        }
        private static void by_doctor3()
        {
            return;
        }
        private static void by_patient()
        {
            return;
        }
        private void patient_completed(IAsyncResult asyncResult)
        {
            if (waiting_doctors>0)
            {
                sema_wait_patient.Release();
                return;
            }
            if (chairs == 0)
            {
                warning.Image = Resource1.warning;
                Thread.Sleep(500);
                warning.Image = null;
                return;
            }
            mutex.WaitOne();
            wait();
            chairs--;
            mutex.Release();
            sema_doctor.WaitOne();
            return;
        }//patient线程的回调函数；
        private void doctor1_completed(IAsyncResult asyncResult)
        {
            while (true)
            {
                if (chairs == 10)
                {
                    doctor1.Image = Resource1.wait_patient;
                    waiting_doctors++;
                    sema_wait_patient.WaitOne();
                    waiting_doctors--;
                    doctor1.Image = Resource1.work;
                    Thread.Sleep(10000);
                    doctor1.Image = Resource1._switch;
                    Thread.Sleep(1000);
                    continue;
                }
                mutex.WaitOne();
                chairs++;
                doctor1.Image = Resource1.work;
                work();
                adjust();
                mutex.Release();
                Thread.Sleep(10000);
                doctor1.Image = Resource1._switch;
                Thread.Sleep(1000);
                doctor1.Image = Resource1.wait_patient;
            }
        }//doctor1线程的回调函数；
        private void doctor2_completed(IAsyncResult asyncResult)
        {
            while (true)
            {
                if (chairs == 10)
                {
                    doctor2.Image = Resource1.wait_patient;
                    waiting_doctors++;
                    sema_wait_patient.WaitOne();
                    waiting_doctors--;
                    doctor2.Image = Resource1.work;
                    Thread.Sleep(10000);
                    doctor2.Image = Resource1._switch;
                    Thread.Sleep(1000);
                    continue;
                }
                mutex.WaitOne();
                chairs++;
                doctor2.Image = Resource1.work;
                work();
                adjust();
                mutex.Release();
                Thread.Sleep(10000);
                doctor2.Image = Resource1._switch;
                Thread.Sleep(1000);
                doctor2.Image = Resource1.wait_patient;
            }
        }//doctor2线程的回调函数；
        private void doctor3_completed(IAsyncResult asyncResult)
        {
            while (true)
            {
                if (chairs == 10)
                {
                    doctor3.Image = Resource1.wait_patient;
                    waiting_doctors++;
                    sema_wait_patient.WaitOne();
                    waiting_doctors--;
                    doctor3.Image = Resource1.work;
                    Thread.Sleep(10000);
                    doctor3.Image = Resource1._switch;
                    Thread.Sleep(1000);
                    continue;
                }
                mutex.WaitOne();
                chairs++;
                doctor3.Image = Resource1.work;
                work();
                adjust();
                mutex.Release();
                Thread.Sleep(10000);
                doctor3.Image = Resource1._switch;
                Thread.Sleep(1000);
                doctor3.Image = Resource1.wait_patient;
            }
        }//doctor3线程的回调函数；

        //操作图形的函数们；
        private void work()
        {
            if (patient1.Image != null)
                patient1.Image = null;
            else if (patient2.Image != null)
                patient2.Image = null;
            else if (patient3.Image != null)
                patient3.Image = null;
            else if (patient4.Image != null)
                patient4.Image = null;
            else if (patient5.Image != null)
                patient5.Image = null;
            else if (patient6.Image != null)
                patient6.Image = null;
            else if (patient7.Image != null)
                patient7.Image = null;
            else if (patient8.Image != null)
                patient8.Image = null;
            else if (patient9.Image != null)
                patient9.Image = null;
            else
                patient10.Image = null;
        }
        private void adjust()
        {
            int sum = 0;
            if (patient1.Image == null)
                sum++;
            if (patient2.Image == null)
                sum++;
            if (patient3.Image == null)
                sum++;
            if (patient4.Image == null)
                sum++;
            if (patient5.Image == null)
                sum++;
            if (patient6.Image == null)
                sum++;
            if (patient7.Image == null)
                sum++;
            if (patient8.Image == null)
                sum++;
            if (patient9.Image == null)
                sum++;
            if (patient10.Image == null)
                sum++;
            sum = 10 - sum;
            patient1.Image = null;
            patient2.Image = null;
            patient3.Image = null;
            patient4.Image = null;
            patient5.Image = null;
            patient6.Image = null;
            patient7.Image = null;
            patient8.Image = null;
            patient9.Image = null;
            patient10.Image = null;
            if (sum >= 1)
                patient1.Image = Resource1.wait;
            if (sum >= 2)
                patient2.Image = Resource1.wait;
            if (sum >= 3)
                patient3.Image = Resource1.wait;
            if (sum >= 4)
                patient4.Image = Resource1.wait;
            if (sum >= 5)
                patient5.Image = Resource1.wait;
            if (sum >= 6)
                patient6.Image = Resource1.wait;
            if (sum >= 7)
                patient7.Image = Resource1.wait;
            if (sum >= 8)
                patient8.Image = Resource1.wait;
            if (sum >= 9)
                patient9.Image = Resource1.wait;
            if (sum == 10)
                patient10.Image = Resource1.wait;
        }
        private void wait()
        {
            if (patient1.Image == null)
                patient1.Image = Resource1.wait;
            else if (patient2.Image == null)
                patient2.Image = Resource1.wait;
            else if (patient3.Image == null)
                patient3.Image = Resource1.wait;
            else if (patient4.Image == null)
                patient4.Image = Resource1.wait;
            else if (patient5.Image == null)
                patient5.Image = Resource1.wait;
            else if (patient6.Image == null)
                patient6.Image = Resource1.wait;
            else if (patient7.Image == null)
                patient7.Image = Resource1.wait;
            else if (patient8.Image == null)
                patient8.Image = Resource1.wait;
            else if (patient9.Image == null)
                patient9.Image = Resource1.wait;
            else
                patient10.Image = Resource1.wait;
        }//把一个空的换成有人；

        private void button1_Click(object sender, EventArgs e)
        {
            if (no_created)
            {
                dele_doctor1 doctor1 = by_doctor1;
                dele_doctor1 doctor2 = by_doctor2;
                dele_doctor1 doctor3 = by_doctor3;
                IAsyncResult asyncResult1 = doctor1.BeginInvoke(doctor1_completed, doctor1);
                IAsyncResult asyncResult2 = doctor2.BeginInvoke(doctor2_completed, doctor2);
                IAsyncResult asyncResult3 = doctor3.BeginInvoke(doctor3_completed, doctor3);
                no_created = false;
                Thread.Sleep(50);
            }
            dele_patient patient = by_patient;
            IAsyncResult asyncResult0 = patient.BeginInvoke(patient_completed, patient);
        }
    }
}
