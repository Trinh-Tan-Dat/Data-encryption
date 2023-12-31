using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Bai2 : Form
    {
        private static Random random = new Random();
        public Bai2()
        {
            InitializeComponent();
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }
        private bool isPrime(long a)
        {
            if (a < 2)
            {
                return false;
            }
            for (long i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public long Gcd(long a, long b)
        {
            while (b != 0)
            {
                long t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private long findE(long phiN)
        {
            Random random = new Random();
            while (true)
            {
                long e = random.Next(2, (int)phiN);
                if (Gcd(e, phiN) == 1 && isPrime(e))
                    return e;
            }
        }

        public static long findD(long a, long m)
        {
            long m0 = m;
            long y = 0, x = 1;
            if (m == 1)
                return 0;
            while (a > 1)
            {
                long q = a / m;
                long t = m;
                m = a % m;
                a = t;
                t = y;
                y = x - q * y;
                x = t;
            }
            if (x < 0)
                x += m0;
            return x;
        }

        public static BigInteger Pow(long a, long b)
        {
            BigInteger result = new BigInteger(a);
            for (long i = 2; i <= b; i++)
            {
                result *= a;
            }
            return result;
        }
        private void checkPrime()
        {
            long n, phiN;
            long p = long.Parse(textBox1.Text);
            long q = long.Parse(guna2TextBox1.Text);
            long eN = long.Parse(guna2TextBox2.Text);
            String plaintext = guna2TextBox3.Text;
            if(plaintext == null)
            {
                MessageBox.Show("Plaintext is not null");
                return;
            }
            if (isPrime(p) == false)
            {
                MessageBox.Show("P is not a prime");
                return;
            }
            if (isPrime(q) == false)
            {
                MessageBox.Show("Q is not a prime");
                return;
            }
            if (isPrime(eN) == false)
            {
                MessageBox.Show("E is not a prime");
                return;
            }
            n = q * p;
            phiN = (p - 1) * (q - 1);
            //long e = findE(phiN);
            long d = findD(eN, phiN);
            long plainText = long.Parse(guna2TextBox3.Text);
            BigInteger temp = Pow(plainText, eN);
            BigInteger cipher = temp % n;
            guna2TextBox4.Text = cipher.ToString();
            guna2TextBox5.Text = d.ToString();
        }
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            string p = textBox1.Text;
            if (string.IsNullOrEmpty(p))
            {
                MessageBox.Show("P is not null");
                return;
            }
            string q = guna2TextBox1.Text;
            if (string.IsNullOrEmpty(q))
            {
                MessageBox.Show("Q is not null");
                return;
            }
            string eN = guna2TextBox2.Text;
            if (string.IsNullOrEmpty(eN))
            {
                MessageBox.Show("E is not null");
                return;
            }
            string plaintext = guna2TextBox3.Text;
            if (string.IsNullOrEmpty(plaintext))
            {
                MessageBox.Show("Plaintext is not null");
                return;
            }
            checkPrime();

        }

        private void panelControl_Paint(object sender, PaintEventArgs e)
        {

        }
        private int GenerateSmallPrime()
        {
            Random random = new Random();
            while (true)
            {
                int num = random.Next(2, 100); // Thay đổi khoảng số nguyên tố tùy ý
                if (isPrime(num))
                    return num;
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            long p = GenerateSmallPrime();
            long q;
            do
            {
                q = GenerateSmallPrime();
            } while (q == p);

            textBox1.Text = p.ToString();
            guna2TextBox1.Text = q.ToString();

            long n = p * q;
            long phiN = (p - 1) * (q - 1);
            long eN = findE(phiN);
            guna2TextBox2.Text = eN.ToString();
        }
    }
}
