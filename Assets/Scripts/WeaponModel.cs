using System.Collections.Generic;

namespace Metal
{
    public class WeaponModel
    {
        //birden cok weapon tutabildigimize gore bunun bir dictionary olmasi lazim
        private Dictionary<int, IWeapon>  _weapons = new();
        
        public IWeapon GetWeapon(int id)=> _weapons.TryGetValue(id, out var value) ? value : default;

        public void AddWeapon(IWeapon weapon)
        {
            _weapons[weapon.Id] = weapon;
        } 
    }
}