using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif

namespace GreenvaleAbbey.Core
{
    [ExecuteAlways]
    public sealed class GreenvaleBlockoutBuilder : MonoBehaviour
    {
        private const string MaterialFolder = "Assets/_Project/Materials/Blockout";

        [Header("Generation")]
        [SerializeField] private bool buildOnEnable = true;
        [SerializeField] private bool reparentGroundPlane = true;

        [Header("Marker Scale")]
        [SerializeField] private Vector3 markerScale = new Vector3(0.6f, 0.6f, 0.6f);

        private readonly Dictionary<string, Material> materials = new Dictionary<string, Material>();

        private void OnEnable()
        {
            if (buildOnEnable)
            {
                Build();
            }
        }

        [ContextMenu("Build Greenvale Blockout")]
        public void Build()
        {
            CacheMaterials();

            Transform landmarkMarkers = EnsureGroup("Landmark_Markers");
            Transform terrain = EnsureGroup("Terrain_Blockout");
            Transform roads = EnsureGroup("Roads_And_Paths");
            Transform abbey = EnsureGroup("Abbey_Hub");
            Transform training = EnsureGroup("Training_Yard");
            Transform forest = EnsureGroup("Forest_Edge");
            Transform farm = EnsureGroup("Farm_Field");
            Transform quarryRoad = EnsureGroup("Quarry_Road");
            Transform quarryEntrance = EnsureGroup("Quarry_Entrance");
            Transform basePlot = EnsureGroup("Base_Plot");
            Transform creek = EnsureGroup("Creek_Or_Pond");
            Transform hilltop = EnsureGroup("Hilltop_Overlook");
            Transform dressing = EnsureGroup("Set_Dressing_Placeholders");

            if (reparentGroundPlane)
            {
                ReparentGroundPlane(terrain);
            }

            BuildMarkers(landmarkMarkers);
            BuildGeometry(roads, abbey, training, forest, farm, quarryRoad, quarryEntrance, basePlot, creek, hilltop, dressing);
        }

        private void BuildMarkers(Transform parent)
        {
            EnsurePrimitive(parent, "AbbeyHub_Marker", PrimitiveType.Sphere, new Vector3(0f, 0.6f, 0f), markerScale, "MAT_Blockout_Abbey");
            EnsurePrimitive(parent, "TrainingYard_Marker", PrimitiveType.Sphere, new Vector3(5f, 0.6f, 2f), markerScale, "MAT_Blockout_BasePlot");
            EnsurePrimitive(parent, "ForestEdge_Marker", PrimitiveType.Sphere, new Vector3(-6f, 0.6f, -5f), markerScale, "MAT_Blockout_Forest");
            EnsurePrimitive(parent, "FarmField_Marker", PrimitiveType.Sphere, new Vector3(-7f, 0.6f, 3f), markerScale, "MAT_Blockout_BasePlot");
            EnsurePrimitive(parent, "QuarryRoad_Marker", PrimitiveType.Sphere, new Vector3(5f, 0.6f, -5f), markerScale, "MAT_Blockout_Road");
            EnsurePrimitive(parent, "QuarryEntrance_Marker", PrimitiveType.Sphere, new Vector3(11f, 0.6f, -9f), markerScale, "MAT_Blockout_Quarry");
            EnsurePrimitive(parent, "BasePlot_Marker", PrimitiveType.Sphere, new Vector3(6f, 0.6f, -2f), markerScale, "MAT_Blockout_BasePlot");
            EnsurePrimitive(parent, "CreekOrPond_Marker", PrimitiveType.Sphere, new Vector3(-7f, 0.6f, -1f), markerScale, "MAT_Blockout_Water");
            EnsurePrimitive(parent, "HilltopOverlook_Marker", PrimitiveType.Sphere, new Vector3(0f, 1.2f, 9f), markerScale, "MAT_Blockout_Abbey");
            EnsurePrimitive(parent, "ScavengerCamp_Marker", PrimitiveType.Sphere, new Vector3(9f, 0.6f, -6f), markerScale, "MAT_Blockout_Quarry");
            EnsurePrimitive(parent, "PlayerStart_Marker", PrimitiveType.Sphere, new Vector3(0f, 0.6f, 1.5f), markerScale, "MAT_Blockout_BasePlot");
        }

        private void BuildGeometry(
            Transform roads,
            Transform abbey,
            Transform training,
            Transform forest,
            Transform farm,
            Transform quarryRoad,
            Transform quarryEntrance,
            Transform basePlot,
            Transform creek,
            Transform hilltop,
            Transform dressing)
        {
            Transform roadParent = EnsureGroup("Road_Path_Blockouts", roads);
            EnsurePrimitive(roadParent, "Road_Path_Blockout_Hub_To_Training", PrimitiveType.Cube, new Vector3(2.5f, 0.04f, 1f), new Vector3(5f, 0.08f, 0.8f), "MAT_Blockout_Road");
            EnsurePrimitive(roadParent, "Road_Path_Blockout_Hub_To_Farm", PrimitiveType.Cube, new Vector3(-3.5f, 0.04f, 1.5f), new Vector3(7f, 0.08f, 0.8f), "MAT_Blockout_Road");
            EnsurePrimitive(roadParent, "Road_Path_Blockout_Hub_To_QuarryRoad", PrimitiveType.Cube, new Vector3(2.5f, 0.04f, -2.5f), new Vector3(0.8f, 0.08f, 6f), "MAT_Blockout_Road");
            EnsurePrimitive(roadParent, "Road_Path_Blockout_QuarryRoad_To_Entrance", PrimitiveType.Cube, new Vector3(8f, 0.04f, -7f), new Vector3(6.5f, 0.08f, 0.8f), "MAT_Blockout_Road");

            EnsurePrimitive(abbey, "Abbey_Main_Blockout", PrimitiveType.Cube, new Vector3(0f, 0.9f, 0f), new Vector3(3.5f, 1.8f, 2.6f), "MAT_Blockout_Abbey");
            EnsurePrimitive(abbey, "BellTower_Blockout", PrimitiveType.Cube, new Vector3(1.55f, 1.7f, 0.95f), new Vector3(1f, 3.4f, 1f), "MAT_Blockout_Abbey");

            EnsurePrimitive(training, "Training_Yard_Fence_Blockout", PrimitiveType.Cube, new Vector3(5f, 0.5f, 2f), new Vector3(4.5f, 1f, 0.25f), "MAT_Blockout_BasePlot");
            EnsurePrimitive(farm, "Farm_Field_Blockout", PrimitiveType.Cube, new Vector3(-7f, 0.05f, 3f), new Vector3(4.5f, 0.1f, 3.5f), "MAT_Blockout_BasePlot");
            EnsurePrimitive(quarryRoad, "Quarry_Road_Blockout", PrimitiveType.Cube, new Vector3(5f, 0.05f, -5f), new Vector3(2f, 0.1f, 4f), "MAT_Blockout_Road");
            EnsurePrimitive(quarryEntrance, "Quarry_Entrance_Blockout", PrimitiveType.Cube, new Vector3(11f, 1f, -9f), new Vector3(3f, 2f, 1.2f), "MAT_Blockout_Quarry");
            EnsurePrimitive(basePlot, "Base_Plot_Blockout", PrimitiveType.Cube, new Vector3(6f, 0.06f, -2f), new Vector3(3.5f, 0.12f, 2.6f), "MAT_Blockout_BasePlot");
            EnsurePrimitive(creek, "Creek_Or_Pond_Blockout", PrimitiveType.Cube, new Vector3(-7f, 0.03f, -1f), new Vector3(4f, 0.06f, 2f), "MAT_Blockout_Water");
            EnsurePrimitive(hilltop, "Hilltop_Overlook_Blockout", PrimitiveType.Cube, new Vector3(0f, 0.6f, 9f), new Vector3(4f, 1.2f, 3f), "MAT_Blockout_Abbey");

            Transform trees = EnsureGroup("Forest_Edge_Tree_Placeholders", forest);
            EnsurePrimitive(trees, "Tree_Placeholder_A", PrimitiveType.Capsule, new Vector3(-6f, 1f, -5f), new Vector3(0.8f, 2f, 0.8f), "MAT_Blockout_Forest");
            EnsurePrimitive(trees, "Tree_Placeholder_B", PrimitiveType.Capsule, new Vector3(-8f, 1f, -4f), new Vector3(0.8f, 2f, 0.8f), "MAT_Blockout_Forest");
            EnsurePrimitive(trees, "Tree_Placeholder_C", PrimitiveType.Capsule, new Vector3(-5f, 1f, -7f), new Vector3(0.8f, 2f, 0.8f), "MAT_Blockout_Forest");

            EnsurePrimitive(dressing, "ScavengerCamp_Blockout", PrimitiveType.Cube, new Vector3(9f, 0.45f, -6f), new Vector3(2f, 0.9f, 1.6f), "MAT_Blockout_Quarry");
        }

        private Transform EnsureGroup(string name)
        {
            return EnsureGroup(name, transform);
        }

        private static Transform EnsureGroup(string name, Transform parent)
        {
            Transform existing = parent.Find(name);
            if (existing != null)
            {
                return existing;
            }

            GameObject group = new GameObject(name);
            group.transform.SetParent(parent, false);
            group.transform.localPosition = Vector3.zero;
            group.transform.localRotation = Quaternion.identity;
            group.transform.localScale = Vector3.one;
            return group.transform;
        }

        private GameObject EnsurePrimitive(Transform parent, string name, PrimitiveType primitiveType, Vector3 localPosition, Vector3 localScale, string materialName)
        {
            Transform existing = parent.Find(name);
            GameObject instance = existing != null ? existing.gameObject : GameObject.CreatePrimitive(primitiveType);
            instance.name = name;
            instance.transform.SetParent(parent, false);
            instance.transform.localPosition = localPosition;
            instance.transform.localRotation = Quaternion.identity;
            instance.transform.localScale = localScale;

            Collider collider = instance.GetComponent<Collider>();
            if (collider != null)
            {
                DestroyImmediateSafe(collider);
            }

            Renderer renderer = instance.GetComponent<Renderer>();
            if (renderer != null && materials.TryGetValue(materialName, out Material material))
            {
                renderer.sharedMaterial = material;
            }

            return instance;
        }

        private void ReparentGroundPlane(Transform terrain)
        {
            Transform ground = transform.Find("Ground_TestPlane");
            if (ground == null)
            {
                return;
            }

            ground.SetParent(terrain, true);
        }

        private void CacheMaterials()
        {
            materials.Clear();
            AddMaterial("MAT_Blockout_Abbey", new Color(0.66f, 0.66f, 0.62f));
            AddMaterial("MAT_Blockout_Road", new Color(0.38f, 0.32f, 0.27f));
            AddMaterial("MAT_Blockout_Forest", new Color(0.2f, 0.42f, 0.22f));
            AddMaterial("MAT_Blockout_Water", new Color(0.2f, 0.42f, 0.62f));
            AddMaterial("MAT_Blockout_Quarry", new Color(0.42f, 0.42f, 0.44f));
            AddMaterial("MAT_Blockout_BasePlot", new Color(0.56f, 0.48f, 0.35f));
        }

        private void AddMaterial(string materialName, Color color)
        {
            Material material = LoadOrCreateMaterial(materialName, color);
            if (material != null)
            {
                materials[materialName] = material;
            }
        }

        private static Material LoadOrCreateMaterial(string materialName, Color color)
        {
#if UNITY_EDITOR
            if (!AssetDatabase.IsValidFolder("Assets/_Project/Materials"))
            {
                AssetDatabase.CreateFolder("Assets/_Project", "Materials");
            }

            if (!AssetDatabase.IsValidFolder(MaterialFolder))
            {
                AssetDatabase.CreateFolder("Assets/_Project/Materials", "Blockout");
            }

            string assetPath = Path.Combine(MaterialFolder, materialName + ".mat").Replace("\\", "/");
            Material existing = AssetDatabase.LoadAssetAtPath<Material>(assetPath);
            if (existing != null)
            {
                return existing;
            }

            Material created = new Material(FindBlockoutShader());
            created.name = materialName;
            created.color = color;
            AssetDatabase.CreateAsset(created, assetPath);
            AssetDatabase.SaveAssets();
            return created;
#else
            Material runtimeMaterial = new Material(FindBlockoutShader());
            runtimeMaterial.name = materialName;
            runtimeMaterial.color = color;
            return runtimeMaterial;
#endif
        }

        private static Shader FindBlockoutShader()
        {
            return Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard") ?? Shader.Find("Sprites/Default");
        }

        private static void DestroyImmediateSafe(Object target)
        {
            if (Application.isPlaying)
            {
                Destroy(target);
            }
            else
            {
                DestroyImmediate(target);
            }
        }
    }
}
