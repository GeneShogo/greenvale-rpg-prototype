using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace GreenvaleAbbey.Core
{
    [ExecuteAlways]
    public sealed class AbbeyHubArtPass01Placer : MonoBehaviour
    {
        private const string ArtPassParentName = "Abbey_Art_Pass_01";

        [Header("Generation")]
        [SerializeField] private bool createIfMissing = true;
        [SerializeField] private bool generated;
        [SerializeField] private bool manualReplacementCleanupApplied;

        private void OnEnable()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying && createIfMissing && !generated && transform.Find(ArtPassParentName) == null)
            {
                CreateArtPass();
            }
            else if (!Application.isPlaying && !manualReplacementCleanupApplied && transform.Find(ArtPassParentName) != null)
            {
                PrepareForManualReplacement();
            }
#endif
        }

#if UNITY_EDITOR
        [ContextMenu("Create Abbey Art Pass 01")]
        private void CreateArtPass()
        {
            Transform artRoot = EnsureChild(transform, ArtPassParentName);

            CreateBuilding(artRoot);
            CreateEntranceProps(artRoot);
            CreateNatureDressing(artRoot);
            PrepareForManualReplacement();

            generated = true;
            manualReplacementCleanupApplied = true;
            EditorUtility.SetDirty(this);
            EditorSceneManager.MarkSceneDirty(gameObject.scene);
        }

        [ContextMenu("Prepare Abbey Hub For Manual Building Replacement")]
        private void PrepareForManualReplacement()
        {
            Transform artRoot = EnsureChild(transform, ArtPassParentName);
            Transform hall = EnsureChild(artRoot, "Main_Hall_Kitbash");
            Transform tower = EnsureChild(artRoot, "Tower_Landmark_Kitbash");
            Transform approach = EnsureChild(artRoot, "Entrance_Approach");
            Transform props = EnsureChild(artRoot, "Entrance_Props");
            Transform nature = EnsureChild(artRoot, "Nature_Set_Dressing");

            SetLocal(hall, Vector3.zero, Quaternion.identity, Vector3.one);
            SetLocal(tower, Vector3.zero, Quaternion.identity, Vector3.one);
            SetLocal(approach, Vector3.zero, Quaternion.identity, Vector3.one);
            SetLocal(props, Vector3.zero, Quaternion.identity, Vector3.one);
            SetLocal(nature, Vector3.zero, Quaternion.identity, Vector3.one);

            DisableExisting(hall, "Hall_Massing_MainBody");
            DisableExisting(hall, "Hall_Massing_Roof");
            DisableExisting(tower, "Tower_Massing_Shaft");
            SetExisting(hall, "Hall_Entrance_Apron_Clearance", new Vector3(0f, 0.03f, -3.1f), Quaternion.identity, new Vector3(3.6f, 0.06f, 1.8f));

            SetExisting(hall, "Hall_Wall_Door_Round", new Vector3(0f, 0.05f, -1.9f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            SetExisting(hall, "Hall_Wall_Back", new Vector3(0f, 0.05f, 1.9f), Quaternion.identity, Vector3.one);
            SetExisting(hall, "Hall_Window_Left", new Vector3(-2.25f, 0.05f, 0f), Quaternion.Euler(0f, 90f, 0f), Vector3.one);
            SetExisting(hall, "Hall_Window_Right", new Vector3(2.25f, 0.05f, 0f), Quaternion.Euler(0f, -90f, 0f), Vector3.one);
            SetExisting(hall, "Hall_Roof_RoundTiles", new Vector3(0f, 2.25f, 0f), Quaternion.identity, Vector3.one);
            SetExisting(hall, "Hall_Door_Round", new Vector3(0f, 0.1f, -2.05f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);

            SetExisting(tower, "Tower_Base", new Vector3(3.2f, 0.05f, 1.55f), Quaternion.Euler(0f, -90f, 0f), Vector3.one);
            SetExisting(tower, "Tower_Middle", new Vector3(3.2f, 1.4f, 1.55f), Quaternion.Euler(0f, -90f, 0f), Vector3.one);
            SetExisting(tower, "Tower_Roof_RoundTiles", new Vector3(3.2f, 2.95f, 1.55f), Quaternion.identity, Vector3.one);

            SetExisting(approach, "Entrance_Stairs", new Vector3(0f, 0f, -3.05f), Quaternion.Euler(0f, 180f, 0f), new Vector3(1.35f, 1.15f, 1.35f));
            SetExisting(approach, "Approach_Path_Stone_A", new Vector3(0f, 0.04f, -4.15f), Quaternion.identity, new Vector3(1.6f, 1f, 1.6f));
            SetExisting(approach, "Approach_Path_Stone_B", new Vector3(0f, 0.04f, -5.15f), Quaternion.identity, new Vector3(1.6f, 1f, 1.6f));

            SetExisting(props, "Entrance_Bench", new Vector3(-2.75f, 0f, -3.65f), Quaternion.Euler(0f, 35f, 0f), Vector3.one);
            SetExisting(props, "Entrance_Barrel", new Vector3(2.15f, 0f, -3.35f), Quaternion.Euler(0f, -20f, 0f), Vector3.one);
            SetExisting(props, "Entrance_Crate", new Vector3(2.75f, 0f, -3.1f), Quaternion.Euler(0f, 18f, 0f), Vector3.one);
            SetExisting(props, "Entrance_Lantern_Left", new Vector3(-1.2f, 1.8f, -2.35f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            SetExisting(props, "Entrance_Banner", new Vector3(1.55f, 2.05f, -2.4f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            SetExisting(props, "Entrance_Fence_Left", new Vector3(-3.4f, 0f, -4.55f), Quaternion.Euler(0f, 25f, 0f), Vector3.one);
            SetExisting(props, "Entrance_Fence_Right", new Vector3(3.4f, 0f, -4.55f), Quaternion.Euler(0f, -25f, 0f), Vector3.one);

            SetExisting(nature, "Abbey_Tree_Left", new Vector3(-5.8f, 0f, 1.8f), Quaternion.Euler(0f, 20f, 0f), Vector3.one);
            SetExisting(nature, "Abbey_Tree_Right", new Vector3(5.9f, 0f, 2.4f), Quaternion.Euler(0f, -35f, 0f), Vector3.one);
            SetExisting(nature, "Flowering_Bush_Left", new Vector3(-4.1f, 0f, -2.5f), Quaternion.Euler(0f, 55f, 0f), Vector3.one);
            SetExisting(nature, "Bush_Right", new Vector3(4.3f, 0f, -2.25f), Quaternion.Euler(0f, -15f, 0f), Vector3.one);
            SetExisting(nature, "Rock_Cluster_Entrance", new Vector3(-4.5f, 0f, -4.35f), Quaternion.Euler(0f, 10f, 0f), Vector3.one);
            SetExisting(nature, "Grass_Tufts_Entrance", new Vector3(4.45f, 0f, -4.15f), Quaternion.identity, Vector3.one);

            CreateReplacementAnchors(artRoot);
            RestoreTemporaryBlockoutReference();
            MoveMarenNearEntrance();

            manualReplacementCleanupApplied = true;
            EditorUtility.SetDirty(this);
            EditorSceneManager.MarkSceneDirty(gameObject.scene);
        }

        private static void CreateBuilding(Transform parent)
        {
            Transform building = EnsureChild(parent, "Main_Hall_Kitbash");
            Place(building, "Hall_Wall_Door_Round", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Wall_Plaster_Door_Round.fbx", new Vector3(0f, 0f, -1.35f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            Place(building, "Hall_Wall_Back", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Wall_Plaster_Straight.fbx", new Vector3(0f, 0f, 1.35f), Quaternion.identity, Vector3.one);
            Place(building, "Hall_Window_Left", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Wall_Plaster_Window_Wide_Round.fbx", new Vector3(-1.8f, 0f, 0f), Quaternion.Euler(0f, 90f, 0f), Vector3.one);
            Place(building, "Hall_Window_Right", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Wall_Plaster_Window_Wide_Round.fbx", new Vector3(1.8f, 0f, 0f), Quaternion.Euler(0f, -90f, 0f), Vector3.one);
            Place(building, "Hall_Roof_RoundTiles", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Roof_RoundTiles_4x6.fbx", new Vector3(0f, 2.1f, 0f), Quaternion.identity, Vector3.one);
            Place(building, "Hall_Door_Round", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Door_1_Round.fbx", new Vector3(0f, 0f, -1.42f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);

            Transform tower = EnsureChild(parent, "Tower_Landmark_Kitbash");
            Place(tower, "Tower_Base", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Wall_UnevenBrick_Straight.fbx", new Vector3(1.8f, 0f, 0.9f), Quaternion.Euler(0f, -90f, 0f), new Vector3(0.8f, 1.2f, 0.8f));
            Place(tower, "Tower_Middle", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Wall_UnevenBrick_Window_Thin_Round.fbx", new Vector3(1.8f, 1.55f, 0.9f), Quaternion.Euler(0f, -90f, 0f), new Vector3(0.8f, 1.2f, 0.8f));
            Place(tower, "Tower_Roof_RoundTiles", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Roof_Tower_RoundTiles.fbx", new Vector3(1.8f, 3.25f, 0.9f), Quaternion.identity, Vector3.one);

            Transform approach = EnsureChild(parent, "Entrance_Approach");
            Place(approach, "Entrance_Stairs", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Stairs_Exterior_Straight.fbx", new Vector3(0f, 0f, -2.25f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            Place(approach, "Approach_Path_Stone_A", "Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/FBX/RockPath_Round_Wide.fbx", new Vector3(0f, 0.02f, -3.2f), Quaternion.identity, Vector3.one);
            Place(approach, "Approach_Path_Stone_B", "Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/FBX/RockPath_Round_Thin.fbx", new Vector3(0f, 0.02f, -4.05f), Quaternion.identity, Vector3.one);
        }

        private static void CreateEntranceProps(Transform parent)
        {
            Transform props = EnsureChild(parent, "Entrance_Props");
            Place(props, "Entrance_Bench", "Assets/ThirdParty/Quaternius/Fantasy Props MegaKit/Exports/FBX/Bench.fbx", new Vector3(-1.8f, 0f, -2.75f), Quaternion.Euler(0f, 35f, 0f), Vector3.one);
            Place(props, "Entrance_Barrel", "Assets/ThirdParty/Quaternius/Fantasy Props MegaKit/Exports/FBX/Barrel.fbx", new Vector3(1.35f, 0f, -2.45f), Quaternion.Euler(0f, -20f, 0f), Vector3.one);
            Place(props, "Entrance_Crate", "Assets/ThirdParty/Quaternius/Fantasy Props MegaKit/Exports/FBX/Crate_Wooden.fbx", new Vector3(1.9f, 0f, -2.25f), Quaternion.Euler(0f, 18f, 0f), Vector3.one);
            Place(props, "Entrance_Lantern_Left", "Assets/ThirdParty/Quaternius/Fantasy Props MegaKit/Exports/FBX/Lantern_Wall.fbx", new Vector3(-0.65f, 1.2f, -1.5f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            Place(props, "Entrance_Banner", "Assets/ThirdParty/Quaternius/Fantasy Props MegaKit/Exports/FBX/Banner_1.fbx", new Vector3(0.95f, 1.35f, -1.55f), Quaternion.Euler(0f, 180f, 0f), Vector3.one);
            Place(props, "Entrance_Fence_Left", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Prop_WoodenFence_Single.fbx", new Vector3(-2.35f, 0f, -3.55f), Quaternion.Euler(0f, 25f, 0f), Vector3.one);
            Place(props, "Entrance_Fence_Right", "Assets/ThirdParty/Quaternius/Medieval Village MegaKit/FBX/Prop_WoodenFence_Single.fbx", new Vector3(2.35f, 0f, -3.55f), Quaternion.Euler(0f, -25f, 0f), Vector3.one);
        }

        private static void CreateNatureDressing(Transform parent)
        {
            Transform nature = EnsureChild(parent, "Nature_Set_Dressing");
            Place(nature, "Abbey_Tree_Left", "Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/FBX (Unity)/CommonTree_1.fbx", new Vector3(-3.2f, 0f, 0.8f), Quaternion.Euler(0f, 20f, 0f), Vector3.one);
            Place(nature, "Abbey_Tree_Right", "Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/FBX (Unity)/CommonTree_3.fbx", new Vector3(3.3f, 0f, -0.1f), Quaternion.Euler(0f, -35f, 0f), Vector3.one);
            Place(nature, "Flowering_Bush_Left", "Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/FBX (Unity)/Bush_Common_Flowers.fbx", new Vector3(-2.35f, 0f, -1.9f), Quaternion.Euler(0f, 55f, 0f), Vector3.one);
            Place(nature, "Bush_Right", "Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/FBX (Unity)/Bush_Common.fbx", new Vector3(2.55f, 0f, -1.75f), Quaternion.Euler(0f, -15f, 0f), Vector3.one);
            Place(nature, "Rock_Cluster_Entrance", "Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/FBX (Unity)/Rock_Medium_1.fbx", new Vector3(-2.9f, 0f, -3.35f), Quaternion.Euler(0f, 10f, 0f), Vector3.one);
            Place(nature, "Grass_Tufts_Entrance", "Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/FBX (Unity)/Grass_Common_Short.fbx", new Vector3(2.85f, 0f, -3.25f), Quaternion.identity, Vector3.one);
        }

        private void DisableReplacedBlockout()
        {
            DisableChild("Abbey_Main_Blockout");
            DisableChild("BellTower_Blockout");
        }

        private void DisableChild(string childName)
        {
            Transform child = transform.Find(childName);
            if (child != null)
            {
                child.gameObject.SetActive(false);
                EditorUtility.SetDirty(child.gameObject);
            }
        }

        private void RestoreTemporaryBlockoutReference()
        {
            EnableChild("Abbey_Main_Blockout");
            EnableChild("BellTower_Blockout");
        }

        private void EnableChild(string childName)
        {
            Transform child = transform.Find(childName);
            if (child != null)
            {
                child.gameObject.SetActive(true);
                EditorUtility.SetDirty(child.gameObject);
            }
        }

        private static Transform EnsureChild(Transform parent, string childName)
        {
            Transform existing = parent.Find(childName);
            if (existing != null)
            {
                return existing;
            }

            GameObject child = new GameObject(childName);
            child.transform.SetParent(parent, false);
            child.transform.localPosition = Vector3.zero;
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = Vector3.one;
            return child.transform;
        }

        private static void SetExisting(Transform parent, string objectName, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            Transform existing = parent.Find(objectName);
            if (existing == null)
            {
                return;
            }

            SetLocal(existing, localPosition, localRotation, localScale);
            existing.gameObject.SetActive(true);
        }

        private static void DisableExisting(Transform parent, string objectName)
        {
            Transform existing = parent.Find(objectName);
            if (existing != null)
            {
                existing.gameObject.SetActive(false);
                EditorUtility.SetDirty(existing.gameObject);
            }
        }

        private static void SetLocal(Transform target, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            target.localPosition = localPosition;
            target.localRotation = localRotation;
            target.localScale = localScale;
            EditorUtility.SetDirty(target.gameObject);
        }

        private static GameObject EnsureMassingPrimitive(Transform parent, string objectName, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, string materialPath, bool removeCollider = false)
        {
            Transform existing = parent.Find(objectName);
            GameObject instance = existing != null ? existing.gameObject : GameObject.CreatePrimitive(PrimitiveType.Cube);
            instance.name = objectName;
            instance.transform.SetParent(parent, false);
            SetLocal(instance.transform, localPosition, localRotation, localScale);

            if (removeCollider)
            {
                Collider collider = instance.GetComponent<Collider>();
                if (collider != null)
                {
                    DestroyImmediate(collider);
                }
            }

            Renderer renderer = instance.GetComponent<Renderer>();
            Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
            if (renderer != null && material != null)
            {
                renderer.sharedMaterial = material;
                EditorUtility.SetDirty(renderer);
            }

            return instance;
        }

        private static void CreateReplacementAnchors(Transform artRoot)
        {
            Transform anchorRoot = EnsureChild(artRoot, "Abbey_Building_Replacement_Anchor");
            SetLocal(anchorRoot, Vector3.zero, Quaternion.identity, Vector3.one);

            Transform main = EnsureChild(anchorRoot, "MainBuilding_DropHere");
            SetLocal(main, new Vector3(0f, 0f, 0.25f), Quaternion.identity, Vector3.one);

            Transform tower = EnsureChild(anchorRoot, "Tower_DropHere");
            SetLocal(tower, new Vector3(3.2f, 0f, 1.55f), Quaternion.identity, Vector3.one);

            Transform entrance = EnsureChild(anchorRoot, "Entrance_DropHere");
            SetLocal(entrance, new Vector3(0f, 0f, -3.1f), Quaternion.identity, Vector3.one);
        }

        private static void MoveMarenNearEntrance()
        {
            GameObject maren = GameObject.Find("Abbey Steward Maren");
            if (maren == null)
            {
                return;
            }

            maren.transform.position = new Vector3(1.45f, 1f, -4.4f);
            maren.transform.rotation = Quaternion.Euler(0f, 205f, 0f);
            EditorUtility.SetDirty(maren);
        }

        private static GameObject Place(Transform parent, string objectName, string assetPath, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            Transform existing = parent.Find(objectName);
            if (existing != null)
            {
                return existing.gameObject;
            }

            Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
            if (asset == null)
            {
                Debug.LogWarning($"Abbey Hub art pass asset missing: {assetPath}");
                return null;
            }

            GameObject instance = PrefabUtility.InstantiatePrefab(asset, parent) as GameObject;
            if (instance == null)
            {
                return null;
            }

            instance.name = objectName;
            instance.transform.localPosition = localPosition;
            instance.transform.localRotation = localRotation;
            instance.transform.localScale = localScale;
            EditorUtility.SetDirty(instance);
            return instance;
        }
#endif
    }
}
