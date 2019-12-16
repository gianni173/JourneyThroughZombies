using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventarioOggetti", menuName = "InvOggetti")]
public class SO_InventarioOggetti : ScriptableObject {

    public List<SO_Struttura> ListaStruct;
    public List<SO_Boost> ListaBoosts;

}
