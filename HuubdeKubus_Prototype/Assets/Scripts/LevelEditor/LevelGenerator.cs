using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D map;

	public ColorToPrefab[] colorMappings;

    public GameObject Floor;

	// Use this for initialization
	void Start () {
		GenerateLevel();
        Instantiate(Floor, transform);
	}

	void GenerateLevel ()
	{
		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x, y);
			}
		}
	}

	void GenerateTile (int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);



        if (pixelColor.a == 0)
		{
			// The pixel is transparrent. Let's ignore it!
			return;
		}


		foreach (ColorToPrefab colorMapping in colorMappings)
		{
            Vector2 position = new Vector2(x, y);

            if (colorMapping.color.Equals(pixelColor))
			{
                Instantiate(colorMapping.prefab, position, colorMapping.prefab.transform.rotation, transform);
            }

        }
	}
	
}
