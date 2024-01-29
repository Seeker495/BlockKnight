using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpriteSplitter))]
public class SpriteSplitterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SpriteSplitter spriteSplitter = (SpriteSplitter)target;

        if (GUILayout.Button("Place Blocks"))
        {
            PlaceBlocks(spriteSplitter);
        }
    }

    private void PlaceBlocks(SpriteSplitter spriteSplitter)
    {
        // 前のブロックを削除する
        while (spriteSplitter.transform.childCount > 0)
        {
            DestroyImmediate(spriteSplitter.transform.GetChild(0).gameObject);
        }

        var textureWidth = spriteSplitter.sourceSprite.texture.width;
        var textureHeight = spriteSplitter.sourceSprite.texture.height;

        // スプライトを分割して配置
        for (int y = 0; y < spriteSplitter.textureSizeY; y++)
        {
            for (int x = 0; x < spriteSplitter.textureSizeX; x++)
            {
                // テクスチャのピクセル座標に変換する
                int pixelX = (int)((float)x / spriteSplitter.textureSizeX * textureWidth);
                int pixelY = (int)((float)y / spriteSplitter.textureSizeY * textureHeight);

                Color pixelColor = spriteSplitter.sourceSprite.texture.GetPixel(pixelX, pixelY);
                if (pixelColor.a <= 0.01f)
                {
                    continue;
                }

                GameObject blockInstance = PrefabUtility.InstantiatePrefab(spriteSplitter.blockPrefab, spriteSplitter.transform) as GameObject;
                float posX = x * 0.1f;
                float posY = y * 0.1f;
                blockInstance.transform.localPosition = new Vector3(posX, posY, 0);
                blockInstance.GetComponent<SpriteRenderer>().color = pixelColor;
            }
        }
    }
}