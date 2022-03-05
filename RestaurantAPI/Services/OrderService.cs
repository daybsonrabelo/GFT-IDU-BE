using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI {
    public class OrderService {
        public Order GenerateOrder(string input) {
            Order order = new Order();
            order.Input = input;
            List<string> listDishes = input.Split(',').ToList();
            order.Output = GenerateOutput(listDishes);

            return order;
        }

        public string GenerateOutput(List<string> list) {
            string vRet = "";
            string type = "";
            int typeCode = 0;
            string timeOfDay = list[0];
            list.Remove(timeOfDay);
            list.Sort();

            foreach(string item in list) {
                typeCode = Int32.Parse(item.Trim());
                type = GetTypeByTimeOfDay(timeOfDay, typeCode);
                if (vRet.Contains(type) && !TypeCanRepeat(timeOfDay, typeCode)) {
                    vRet += "error";
                    return vRet;
                } else {
                    vRet += type + ", ";
                }
            }

            vRet = RemoveEndComma(vRet);
            list = vRet.Split(',').ToList();

            return GetOutputSumarryzed(timeOfDay, list);
        }

        private  string GetOutputSumarryzed(string time, List<string> list) {
            string vRet = "";
            int count = 0;
            string itemType = "";
            foreach(string item in list) {
                itemType = item.Trim();
                if (time == "morning") {
                    if (item.Trim() == "coffee") {
                        if (!vRet.Contains("coffee")) {
                            count = list.Where(t => t.Trim() == "coffee").Count();
                            if (count > 1) {
                                vRet+= $"{item.Trim()}({count}x), ";
                            } else {
                                vRet+= item.Trim() + ", ";
                            }
                        }
                    } else {
                        vRet+= item.Trim() + ", ";
                    }
                } else {
                    if (item.Trim() == "potato") {
                        if (!vRet.Contains("potato")) {
                            count = list.Where(t => t.Trim() == "potato").Count();
                            if (count > 1) {
                                vRet+= $"{item.Trim()}({count}x), ";
                            } else {
                                vRet+= item.Trim() + ", ";
                            }
                        }
                    } else {
                        vRet+= item.Trim() + ", ";
                    }
                }
            }

            return RemoveEndComma(vRet);
        }

        public string RemoveEndComma(string text) {
            if (text.EndsWith(", "))
                text = text.Remove(text.Length - 2, 2);
            return text;
        }

        private bool TypeCanRepeat(string time, int type) {
            bool vRet = false;
            if (time == "morning") {
                vRet = (type == 3);
            } else {
                vRet = (type == 2);
            }
            return vRet;
        }

        private string GetTypeByTimeOfDay(string time, int type) {
            string vRet = "";
            if (time == "morning") {
                switch (type) {
                    case 1:
                        vRet = "eggs";
                        break;
                    case 2:
                        vRet = "toast";
                        break;
                    case 3:
                        vRet = "coffee";
                        break;
                    case 4:
                        vRet = "error";
                        break;
                    default:
                        vRet = "error";
                        break;
                }
            } else {
                switch (type) {
                    case 1:
                        vRet = "steak";
                        break;
                    case 2:
                        vRet = "potato";
                        break;
                    case 3:
                        vRet = "wine";
                        break;
                    case 4:
                        vRet = "cake";
                        break;
                    default:
                        vRet = "error";
                        break;
                }
            }
            return vRet;
        }

    }
}