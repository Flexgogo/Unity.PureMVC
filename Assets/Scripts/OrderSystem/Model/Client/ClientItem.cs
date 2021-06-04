
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 13:44:17
* Description:$safeprojectname$
==========================================*/

namespace OrderSystem
{
    public enum E_ClientState
    {
        Ideal=0,
        WaitMenu = 1,
        WaitFood = 2,
        EatFood = 3,
        Pay = 4,
    }

    public class ClientItem
    {
        public int id { get; set; }
        public int population { get; set; }
        public int state { get; set; }

        public ClientItem( int id , int population,int state )
        {
            this.id = id;
            this.population = population;
            this.state = state;
        }
        public override string ToString()
        {
            return id + "号桌" +"\n" + population + "个人" + "\n" + returnState(state);
        }
        private string returnState( int state )
        {
            if (state.Equals(E_ClientState.Ideal))
                return "空桌子";
            else if (state.Equals(E_ClientState.WaitMenu))
                return "等待菜单";
            else if (state.Equals(E_ClientState.WaitFood))
                return "等待上菜";
            else if (state.Equals(E_ClientState.EatFood))
                return "就餐中";
            return "已经结账";
        }
    }
}