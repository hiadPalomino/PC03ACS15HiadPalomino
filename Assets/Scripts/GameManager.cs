using UnityEngine;

public static class GameManager
{
    private static int totalKills = 0; // Total de enemigos eliminados

    public static int TotalKills
    {
        get { return totalKills; }
        set { totalKills = value; }
    }

    public static void ResetTotalKills()
    {
        totalKills = 0; // Reinicia el contador de bajas
    }
}
