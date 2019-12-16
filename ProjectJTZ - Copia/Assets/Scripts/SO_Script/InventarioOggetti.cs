using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventarioOggetti", menuName = "InvOggetti")]
public class InventarioOggetti : ScriptableObject {

    public List<StructureTemplate> ListaStruct;
    public List<Boost> ListaBoosts;

}
