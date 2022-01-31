using System.Data.SqlClient;

namespace InsertQuery
{
    public partial class Form1 : Form
    {
        
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"database=Cinema; data source=LAPTOP-OLGLBFRN\SQLEXPRESS; integrated security=SSPI;";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Subscriber(Username, Number, Email, Hash, Salt) values('" + txtSubscriber.Text + "','" + txtId.Text + "','" + txtEmail.Text + "','" + txtHash.Text + "','" + txtSalt.Text +"')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved Successfully", "Message");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Subscriber SET Email='"+txtEmail.Text+"' , Hash='"+txtHash.Text+"' , Salt='"+txtSalt.Text+"' WHERE Username='"+txtSubscriber.Text+"' AND Number='"+txtId.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Successfully", "Message");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Friend WHERE (FUsername='" + txtSubscriber.Text + "' AND FNumber='" + txtId.Text + "') OR (TUsername='" + txtSubscriber.Text + "' AND TNumber='" + txtId.Text + "')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM Subscriber WHERE Number='" + txtId.Text + "' AND Username='"+txtSubscriber.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete Successfully", "Message");
        }

        private void btnFriendSave_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Friend(FUsername, FNumber, TUsername, TNumber) values('" + txtFUsername.Text + "','" + txtFid.Text + "','"  + txtFFUsername.Text + "','" + txtFFId.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved Successfully", "Message");
        }

        private void btnFriendDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Friend WHERE FUsername='" + txtFUsername.Text + "' AND FNumber='" + txtFid.Text + "' AND TUsername='" + txtFFUsername.Text + "' AND TNumber='" + txtFFId.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete Successfully", "Message");
        }
    }
}