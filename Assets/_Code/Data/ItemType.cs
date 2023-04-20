using System.Runtime.Serialization;

namespace _Code.Data
{
    public enum ItemType
    {
        [EnumMember(Value = "UI_icon_cash")] Cash,
        [EnumMember(Value = "UI_icon_gold_pile")] GoldPile,
        [EnumMember(Value = "ui_icon_render_cons_grenade_electric")] GrenadeElectric,
        [EnumMember(Value = "ui_icon_render_cons_grenade_m67")] GrenadeM67,
        [EnumMember(Value = "ui_icon_render_cons_grenade_snowball")] GrenadeSnowball,
        [EnumMember(Value = "ui_icon_render_cons_healthshot_2")] HealthShot2,
        [EnumMember(Value = "ui_icon_render_cons_healthshot_2_adrenaline")] HealthShot2Adrenaline,
        [EnumMember(Value = "ui_icon_render_cons_medkit_easter")] MedkitEaster,
        [EnumMember(Value = "ui_icon_render_t_cons_grenade_emp")] GrenadeEmp,
        [EnumMember(Value = "ui_icon_render_t_cons_c4")] C4,
    }
    
    
}