using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Input", menuName = "InputPersonalizzati")]
public class Input : ScriptableObject {

    public KeyCode sparo;
    public KeyCode piazzamento;
    public KeyCode sprint;
    public KeyCode switchSparoBuilding;
    public KeyCode interazione;
    public KeyCode utilizzoBoost;
    public KeyCode ruotaBuildOrario;
    public KeyCode ruotaBuildAntiorario;
    public KeyCode puntatoreCamper;
    public KeyCode pausa;
    public KeyCode utilizzoMed;
    public KeyCode debugSpawnZombieWave;
    public KeyCode debugGoToMenu;
    public KeyCode debugStopStartSpawns;
    public KeyCode debugHealthCheat;
    public KeyCode debugAmmoCheat;
    public KeyCode debugResetGameController;

}
