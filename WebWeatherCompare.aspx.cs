using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WeatherService1
{
    public partial class WebWeatherCompare : System.Web.UI.Page
    {
        public StringBuilder info1 = new StringBuilder();
        public StringBuilder info2 = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {   //only one time
            if (!IsPostBack) //avoid page refresh after button "More info" click event 
            {
                CountryDropList1(null, new EventArgs());
                CountryDropList2(null, new EventArgs());
                LabelInfo1.Visible = false;
                LabelInfo2.Visible = false;
            }
        }
        protected void CountryDropList1(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   // added maxReceivedMessageSize="20000000" in Web.config or BasicHttpBindig binding with MaxReceivedMessageSize = 20000000
                ServiceReferenceWeather.GlobalWeatherSoapClient soapService = new ServiceReferenceWeather.GlobalWeatherSoapClient("GlobalWeatherSoap");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(soapService.GetCitiesByCountry(""));
                XmlNodeList xmlNodes = xmlDoc.GetElementsByTagName("Country");
                List<string> countryList = new List<string>();
                foreach (XmlNode node in xmlNodes)
                {
                    if (!countryList.Contains(node.InnerText))
                    {
                        countryList.Add(node.InnerText);
                    }
                }
                countryList.Sort();
                DropDownList1Countries.DataSource = countryList;
                DropDownList1Countries.DataBind();
                CityDropList1(null, new EventArgs());
            }
        }

        protected void CityDropList1(object sender, System.EventArgs e)
        {
            CleanLabels(null, new EventArgs());
            if (this.DropDownList1Countries.SelectedItem != null)
            {
                List<string> cityList = new List<string>();
                ServiceReferenceWeather.GlobalWeatherSoapClient soapService = new ServiceReferenceWeather.GlobalWeatherSoapClient("GlobalWeatherSoap");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(soapService.GetCitiesByCountry(DropDownList1Countries.SelectedValue));
                XmlNodeList xmlNodes = xmlDoc.GetElementsByTagName("City");
                foreach (XmlNode node in xmlNodes)
                {
                    if (!cityList.Contains(node.InnerText))
                    {
                        cityList.Add(node.InnerText);
                    }
                }
                cityList.Sort();
                DropDownList1Cities.DataSource = cityList;
                DropDownList1Cities.DataBind();
            }
            else
            {
                DropDownList1Cities.DataSource = null;
                DropDownList1Cities.DataBind();
            }
        }
        protected void CountryDropList2(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   // added maxReceivedMessageSize="20000000" in Web.config or BasicHttpBindig binding with MaxReceivedMessageSize = 20000000
                ServiceReferenceWeather.GlobalWeatherSoapClient soapService = new ServiceReferenceWeather.GlobalWeatherSoapClient("GlobalWeatherSoap");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(soapService.GetCitiesByCountry(""));
                XmlNodeList xmlNodes = xmlDoc.GetElementsByTagName("Country");
                List<string> countryList = new List<string>();
                foreach (XmlNode node in xmlNodes)
                {
                    if (!countryList.Contains(node.InnerText))
                    {
                        countryList.Add(node.InnerText);
                    }
                }
                countryList.Sort();
                DropDownList2Countries.DataSource = countryList;
                DropDownList2Countries.DataBind();
                CityDropList2(null, new EventArgs());
            }
        }

        protected void CityDropList2(object sender, System.EventArgs e)
        {
            CleanLabels(null, new EventArgs());
            if (this.DropDownList1Countries.SelectedItem != null)
            {
                List<string> cityList = new List<string>();
                ServiceReferenceWeather.GlobalWeatherSoapClient soapService = new ServiceReferenceWeather.GlobalWeatherSoapClient("GlobalWeatherSoap");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(soapService.GetCitiesByCountry(DropDownList2Countries.SelectedValue));
                XmlNodeList xmlNodes = xmlDoc.GetElementsByTagName("City");
                foreach (XmlNode node in xmlNodes)
                {
                    if (!cityList.Contains(node.InnerText))
                    {
                        cityList.Add(node.InnerText);
                    }
                }
                cityList.Sort();
                DropDownList2Cities.DataSource = cityList;
                DropDownList2Cities.DataBind();
            }
            else
            {
                DropDownList2Cities.DataSource = null;
                DropDownList2Cities.DataBind();
            }
        }

        protected void Button1Compare_Click(object sender, EventArgs e)
        {
            string temperature1 = null;
            string temperature2 = null;
            ServiceReferenceWeather.GlobalWeatherSoapClient soapService = new ServiceReferenceWeather.GlobalWeatherSoapClient("GlobalWeatherSoap");
            string xmlInfo = soapService.GetWeather(DropDownList1Cities.SelectedValue, DropDownList1Countries.SelectedValue);
            string xmlInfo2 = soapService.GetWeather(DropDownList2Cities.SelectedValue, DropDownList2Countries.SelectedValue);    
            bool success = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlInfo);
                XmlNode xmlNode = xmlDoc.DocumentElement;
                foreach (XmlNode node in xmlNode.ChildNodes)
                {
                    if (node.Name == "Status")
                    {
                        success = node.InnerText == "Success";
                    }
                    else
                    {
                        info1.Append("<b>" + node.Name + ":</b> " + node.InnerText + "<br/>");
                        if (node.Name == "Temperature")
                        {
                            temperature1 = node.InnerText;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                info1.Append("Data Not Found");
                LabelTemperature1.Text = "Data Not Found";
            }
            bool success2 = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlInfo2);
                XmlNode xmlNode = xmlDoc.DocumentElement;
                foreach (XmlNode node in xmlNode.ChildNodes)
                {
                    if (node.Name == "Status")
                    {
                        success2 = node.InnerText == "Success";
                    }
                    else
                    {
                        info2.Append("<b>" + node.Name + ":</b> " + node.InnerText + "<br/>");
                        if (node.Name == "Temperature")
                        {
                            temperature2 = node.InnerText;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                info2.Append("Data Not Found");
                LabelTemperature2.Text = "Data Not Found";
            }
            if (success && success2)
            {
                LabelTemperature1.Text = temperature1; // Temperature format = "xx F (xx C)"
                LabelTemperature2.Text = temperature2;
                LabelInfo1.Text = info1.ToString();
                LabelInfo2.Text = info2.ToString();
                temperature1 = temperature1.Substring(temperature1.IndexOf("(") + 1, temperature1.IndexOf(")") - temperature1.IndexOf("(") - 3);
                decimal temp1 = Convert.ToDecimal(temperature1);
                temperature2 = temperature2.Substring(temperature2.IndexOf("(") + 1, temperature2.IndexOf(")") - temperature2.IndexOf("(") - 3);
                decimal temp2 = Convert.ToDecimal(temperature2);
                if (temp1 == temp2)
                {
                    LabelResultComp.Text = "City 1 or 2";
                }
                else
                {
                    if (temp1 > temp2)
                    {
                        LabelResultComp.Text = "City 1 Better";
                        Table1.Rows[1].Cells[0].BackColor = System.Drawing.Color.LawnGreen;
                    }
                    else
                    {
                        LabelResultComp.Text = "City 2 Better";
                        Table1.Rows[1].Cells[2].BackColor = System.Drawing.Color.LawnGreen;
                    }
                }
            }
            else
            {
                LabelResultComp.Text = "Some Data Not Found";
            }

        }

        protected void CleanLabels(object sender, EventArgs e)
        {
            Table1.Rows[1].Cells[0].BackColor = System.Drawing.Color.White;
            Table1.Rows[1].Cells[2].BackColor = System.Drawing.Color.White;
            LabelTemperature1.Text = "";
            LabelTemperature2.Text = "";
            LabelInfo1.Text = "";
            LabelInfo2.Text = "";
            LabelInfo1.Visible = false;
            LabelInfo2.Visible = false;
            LabelResultComp.Text = "";
        }

        protected void Button2Info1_Click(object sender, EventArgs e)
        {
            LabelInfo1.Visible = true;
        }

        protected void Button3Info2_Click(object sender, EventArgs e)
        {
            LabelInfo2.Visible = true;
        }
    }
    
}