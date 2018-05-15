using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AqiTransferData
{
    class TransferData
    {
        public static void MainActivity()
        {
            List<PollutantModel> dataList = new List<PollutantModel>();
            DbHelper db = new DbHelper();
            MySqlConnection conn = null;
            int j = 0;
            try
            {
                conn=db.openConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT `pollutant_name`,`pollutant_value`,`station_id`,`active`,`created_date` FROM `tbl_pollutant` WHERE `created_date`<(CURDATE() - INTERVAL 7 DAY);", conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    PollutantModel data = new PollutantModel();
                    data.pol_name= (dr["pollutant_name"]).ToString();
                    data.pol_val = (dr["pollutant_value"]).ToString();
                    data.station_id = Convert.ToInt32(dr["station_id"].ToString());
                    //data.active = Convert.ToBoolean((dr["active"]).ToString());
                    data.createdDate= Convert.ToDateTime((dr["created_date"]).ToString());
                 

                    dataList.Add(data);
                    j++;
                }
               
            }
            catch(Exception ex)
            {

            }

            finally
            {
                db.closeConnection();
            }

            try
            {
                if(j!=0)
                {
                    conn = db.openConnection();
                    for (int i = 0; i < j; i++)
                    {
                        //  DateTime dateValue = DateTime.Now;
                        // string dateTime = dataList[i].createdDate.ToString("yyyy-MM-dd HH:mm:ss");
                        string date = dataList[i].createdDate.ToString();


                        MySqlCommand cmd = new MySqlCommand("INSERT INTO `tbl_pollutant_history` (`pollutant_name`,`pollutant_value`,`station_id`,`date`,`created_date`) VALUES('" + dataList[i].pol_name + "'," + dataList[i].pol_val + "," + dataList[i].station_id + ",'" + date + "',NOW());", conn);
                        cmd.ExecuteNonQuery();
                        
                    }
                }
               
              
               
            }
            catch(Exception ex)
            {

            }
            finally
            {
                db.closeConnection();
            }

            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand("delete from `tbl_pollutant` where `created_date`<(CURDATE() - INTERVAL 7 DAY);", conn);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                db.closeConnection();
            }

            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand("delete from `tbl_pollutant_history` where `created_date`<(CURDATE() - INTERVAL 730 DAY);", conn);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
