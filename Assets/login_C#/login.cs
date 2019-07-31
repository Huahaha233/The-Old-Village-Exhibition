using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour {
    public InputField Guser;
    public InputField Gpsw;
    public InputField Gcode;
    private string Code;
    public static bool isregister = false;//判断用户是否为注册用户
    // Use this for initialization
    void Start() {
        CreatDatabase();
        CreatTable();
    }

    // Update is called once per frame
    void Update() {

    }
    private static void CreatDatabase()//创建数据库
    {
        string creatdatabase = "Data Source=localhost;Persist Security Info=yes;UserId=root;PWD=123456";
        string MysqlStatment = "CREATE DATABASE IF NOT EXISTS oldvillage DEFAULT CHARSET utf8 COLLATE utf8_general_ci;";
        MySqlConnection conn = new MySqlConnection(creatdatabase);
        try
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand(MysqlStatment, conn);
            comm.ExecuteNonQuery();
            Debug.Log("数据库建立完成");
        }
        catch
        {

        }
        finally
        {
            conn.Close();
        }

    }

    private static void CreatTable()//创建数据库表
    {
        string sql = "CREATE TABLE IF NOT EXISTS `User` (`User_id` INT UNSIGNED AUTO_INCREMENT,  `User_name` CHAR(10) NOT NULL, `User_psw` CHAR(10) NOT NULL,PRIMARY KEY(`User_id`)) DEFAULT CHARSET = utf8";
        ChangeMysql(sql);
        string sql1 = "CREATE TABLE IF NOT EXISTS `User_login` (`num` INT UNSIGNED AUTO_INCREMENT,  `User_name` CHAR(10) NOT NULL, `Login_time` DATETIME NOT NULL,PRIMARY KEY(`num`)) DEFAULT CHARSET = utf8";
        ChangeMysql(sql1);
        string sql2 = "CREATE TABLE IF NOT EXISTS `User_registe` (`registe_num` INT UNSIGNED AUTO_INCREMENT,  `User_name` CHAR(10) NOT NULL, `User_psw` CHAR(20) NOT NULL,`registe_time` DATETIME NOT NULL,PRIMARY KEY(`registe_num`)) DEFAULT CHARSET = utf8";
        ChangeMysql(sql2);
    }

    private static void ChangeMysql(string Mysql_change)//对数据库进行操作，通过其他函数传入的参数进行操作
    {
        string Mysql_str = "server=localhost;user id=root;password=123456;database=oldvillage";
        MySqlConnection myconn = new MySqlConnection(Mysql_str);
        try
        {
            myconn.Open();
            MySqlCommand mycomm = new MySqlCommand(Mysql_change, myconn);
            mycomm.ExecuteNonQuery();
            Debug.Log("建表完成");
        }
        catch (MySqlException ex)
        {
        }
        finally
        {
            myconn.Close();
        }
    }
    //public void ChangeMysql(string Mysql_change)//对数据库进行操作，通过其他函数传入的参数进行操作
    //{
    //    string Mysql_str = "server=localhost;user id=root;password=123456;database=oldvillage";
    //    MySqlConnection myconn = new MySqlConnection(Mysql_str);
    //    try
    //    {
    //        myconn.Open();
    //        MySqlCommand mycomm = new MySqlCommand(Mysql_change, myconn);
    //        mycomm.ExecuteNonQuery();
    //        Debug.Log("写入成功");
    //    }
    //    catch (MySqlException ex)
    //    {
    //    }
    //    finally
    //    {
    //        myconn.Close();
    //    }
    //}


    public int ReadMysql(string name, string psw)
    {
        int find = 0;
        string connetStr = "server=localhost;user id=root;password=123456;database=oldvillage";//注意Sslmode要赋值为none，否则无法连接到数据库   
        MySqlConnection conn = new MySqlConnection(connetStr);
        MySqlCommand command = null;
        MySqlDataReader dataReader = null;
        try
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM User_registe";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (name == dataReader.GetString(1) && psw == dataReader.GetString(2))
                {
                    find = 1;//find为1时，证明数据库中用户名已存在
                    break;
                }
            }
        }
        catch
        {
            Debug.Log("未能连接到数据库！");
        }
        finally { conn.Close(); }
        return find;

    }



    /*判断注册用户名是都存在*/
    public void Judge()
    {
        isregister = true;//初始化

        Code = Mysqlconn.Code;//放于此处用于更新code的值
        if (ReadMysql(Guser.text, Gpsw.text) == 1 && (Code == Gcode.text)||(Guser.text=="1"&& Gpsw.text=="1"))//括号中后面的代码用于用户测试的账号与密码
        {
           transform.Find("Tips").GetComponent<Text>().text = "登录成功！";
            Collsion.isregiste = true;//给类LinkMysql中的值赋值，证明本用户不是注册用户
            Invoke("ToScene", 1f);//延迟1秒后跳转页面
        }
        else
        {
            transform.Find("Tips").GetComponent<Text>().text = "信息错误！";
            //VerificationCode.Click();//验证码错误使用需要刷新验证码
        }


    }

    private void ToScene()
    {
        isregister = true;//登录成功，为已注册用户
        SceneManager.LoadScene("SampleScene");
    }

    public void Toregiste()
    {
        SceneManager.LoadScene("registe");
    }

    public void Forget()
    {
        SceneManager.LoadScene("Forget");
    }
    public void Totravle()
    {
        isregister = false;
        SceneManager.LoadScene("SampleScene");
    }

    //退出程序
    public void OUT()
    {
        Application.Quit();
    }
}
