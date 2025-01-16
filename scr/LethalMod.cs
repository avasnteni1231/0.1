using BepInEx;
using UnityEngine;

namespace LethalCompanyMod
{
    [BepInPlugin("com.seuNome.lethalmod", "Lethal Company Mod", "1.0.0")]
    public class LethalMod : BaseUnityPlugin
    {
        private bool godMode = false;
        private bool noClip = false;
        private bool espObjects = false;
        private bool espEnemies = false;
        private bool espPlayers = false;
        private bool espDoors = false;

        private float noClipSpeed = 4.5f;
        private float grabDistance = 5.0f;

        private GameObject player;

        void Start()
        {
            player = GameObject.FindWithTag("Player"); // Certifique-se de que a tag do jogador esteja correta.
        }

        void Update()
        {
            // Abre a GUI ao pressionar "Insert"
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                // Mostra a interface gráfica
                ToggleGUI();
            }

            // NoClip Functionality
            if (noClip)
            {
                HandleNoClip();
            }
        }

        void ToggleGUI()
        {
            // Aqui você implementará a GUI no estilo Unity GUI ou IMGUI.
            // Vou criar a interface inicial.

            // Exemplo básico de GUI
            GUILayout.BeginArea(new Rect(10, 10, 300, 500));
            GUILayout.Label("Lethal Company Mod");

            if (GUILayout.Button("GodMode: " + (godMode ? "ON" : "OFF")))
            {
                godMode = !godMode;
                if (godMode)
                    EnableGodMode();
                else
                    DisableGodMode();
            }

            if (GUILayout.Button("NoClip: " + (noClip ? "ON" : "OFF")))
            {
                noClip = !noClip;
            }

            noClipSpeed = GUILayout.HorizontalSlider(noClipSpeed, 1f, 10f);
            GUILayout.Label("NoClip Speed: " + noClipSpeed);

            grabDistance = GUILayout.HorizontalSlider(grabDistance, 0f, 10000f);
            GUILayout.Label("Grab Distance: " + grabDistance);

            if (GUILayout.Button("ESP Objects: " + (espObjects ? "ON" : "OFF")))
            {
                espObjects = !espObjects;
                ToggleESP("object", espObjects);
            }

            if (GUILayout.Button("ESP Enemies: " + (espEnemies ? "ON" : "OFF")))
            {
                espEnemies = !espEnemies;
                ToggleESP("enemy", espEnemies);
            }

            if (GUILayout.Button("ESP Players: " + (espPlayers ? "ON" : "OFF")))
            {
                espPlayers = !espPlayers;
                ToggleESP("player", espPlayers);
            }

            if (GUILayout.Button("ESP Doors: " + (espDoors ? "ON" : "OFF")))
            {
                espDoors = !espDoors;
                ToggleESP("door", espDoors);
            }

            GUILayout.EndArea();
        }

        void EnableGodMode()
        {
            // Implementar a lógica de vida infinita aqui.
            player.GetComponent<Health>().Infinite = true; // Exemplo genérico.
        }

        void DisableGodMode()
        {
            // Desabilitar o modo Deus.
            player.GetComponent<Health>().Infinite = false; // Exemplo genérico.
        }

        void HandleNoClip()
        {
            if (Input.GetKey(KeyCode.W))
                player.transform.position += player.transform.forward * noClipSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.S))
                player.transform.position -= player.transform.forward * noClipSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
                player.transform.position -= player.transform.right * noClipSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D))
                player.transform.position += player.transform.right * noClipSpeed * Time.deltaTime;
        }

        void ToggleESP(string type, bool enable)
        {
            // Implementar lógica para adicionar contorno ou luz aos objetos específicos.
            // Por exemplo: encontre objetos pelo tipo e aplique efeito de contorno.
        }
    }
}
