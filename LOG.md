## Commit Log / Done

#### [Added Prototpye Planets](https://github.com/SaulHarwin/Computing-Project-Solar-System/commit/907bf6c7086dc7f5937126a0b605d1f39f0bb316)

Created the solar system with all the planet included but instead of having making all of planet by adding the planet script I have just created spheres as place fillers and later I will go through them and add the planet script and make it look like the design planet. However for now they will stay like this. 

![Prototype Planet](https://instagram.ffab1-2.fna.fbcdn.net/v/t51.2885-15/e15/s480x480/219914662_405504287550097_6923506401104860763_n.jpg?_nc_ht=instagram.ffab1-2.fna.fbcdn.net&_nc_cat=101&_nc_ohc=9rlLXKcsRIIAX_S549H&edm=ABJHkxYAAAAA&ccb=7-4&oh=3bce7a0f22b15adf0d0248582034e040&oe=60FD8471&_nc_sid=fa978c&ig_cache_key=MjYyMjIwNjg1ODUwMDcyMDUwMQ%3D%3D.2-ccb7-4)

#### [Making of a Moon](https://github.com/SaulHarwin/Computing-Project-Solar-System/commit/4b75a09df31145ef00cd95223f27f50208bc0178)

The moon creation was very easy. All I have done is created a new material that the object uses, I've attached the planet script adjusted the parrameters to make it look a little like a moon. Then I create a gradient for it. 

![](https://instagram.ffab1-2.fna.fbcdn.net/v/t51.2885-15/e15/219822941_238791271244813_2899573908628475843_n.jpg?_nc_ht=instagram.ffab1-2.fna.fbcdn.net&_nc_cat=105&_nc_ohc=QHfN9U3pt_kAX8_lZqx&edm=ABJHkxYAAAAA&ccb=7-4&oh=43e4d2337b79e75532b7e7780d52ee77&oe=60FE9C55&_nc_sid=fa978c&ig_cache_key=MjYyMjIwMDkxMDQ1NzQ5ODc0NQ%3D%3D.2-ccb7-4)

#### [Setup of PB Graph](https://github.com/SaulHarwin/Computing-Project-Solar-System/commit/ae95981e7fab570737b1f25566936aad4654f621)

Creating a [PB graph](https://github.com/SaulHarwin/Computing-Project-Solar-System/blob/ae95981e7fab570737b1f25566936aad4654f621/Assets/Scripts/Graphics/Planet.shadergraph) for the planet terrain that enable us to colour the each vertice based on the height value. This allows us to colour the lowerest terrain blue to look like the sea. 

![Planet](https://instagram.ffab1-1.fna.fbcdn.net/v/t51.2885-15/fr/e15/s1080x1080/219950277_412894160071461_839517647105128569_n.jpg?_nc_ht=instagram.ffab1-1.fna.fbcdn.net&_nc_cat=109&_nc_ohc=xLj3AWiPzYIAX-u3oB5&edm=ABJHkxYAAAAA&ccb=7-4&oh=a369321ae6ac69a1ae38a04935ba4839&oe=60FE4540&_nc_sid=fa978c&ig_cache_key=MjYyMjE5OTg0NjUzMDM3MDg2MQ%3D%3D.2-ccb7-4)

#### [Setup of URP](https://github.com/SaulHarwin/Computing-Project-Solar-System/commit/97abdc9b24c501f2dc280f79ddd2ff43841ed6bf)

A simple commit just setting up the the project to use the Universal Render Pipeline. This will later enable use to use the PB graphs.

#### [Added the Property recedeIntoSphereStrength](https://github.com/SaulHarwin/Computing-Project-Solar-System/commit/c92b3dbecea8b66c88dbad412fd68b555f9c87d2)

This was created to create the illusion that the land was falling beneath the sea. This was done by creating a variable called recedeIntoSphereStrength and adding the following line into the [noiseProccesor](https://github.com/SaulHarwin/Computing-Project-Solar-System/blob/c92b3dbecea8b66c88dbad412fd68b555f9c87d2/Assets/Scripts/NoiseProcessor.cs).Evalute() function before returning the value.

```cs 
noiseValue = Mathf.Max(0, noiseValue-settings.rededeIntoSphereStrength);
```
```cs
public float Evaluate(Vector3 point) {
    float noiseValue = 0;
    float frequency = settings.frequency;
    float amplitude = settings.amplitude;

    for (var o = 0; o < settings.octaves; o++)
    {
        float v = noise.Evaluate(point * frequency + settings.offset);
        noiseValue += (v+1) * 0.5f * amplitude;
        frequency *= settings.lacunarity;
        amplitude *= settings.percistance;
    }
    noiseValue = Mathf.Max(0, noiseValue-settings.rededeIntoSphereStrength);
    return noiseValue * settings.amplitude;
}
```
Its effects are best illustrated in the following image which shows the land pretruding from the blue water.
![Earth Like Planet](https://cdn.discordapp.com/attachments/789152776135114796/867112816954703902/unknown.png)

#### [Procedural Planet](https://github.com/SaulHarwin/Computing-Project-Solar-System/commit/ae4af1ff050f822d48ce254e41cfec6a4ca0e449)
To create the sphere that the planet will be created appon I use a cube sphere. A cube sphere is a cube that is then blown up by a radius so that each vertice is a distance of the radius away from the centre. 
![Cube Sphere](https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Facko.net%2Ffiles%2Fmaking-worlds%2Fplanets-1-cubemap.png&f=1&nofb=1)

This is done by this code in the [PlanetFace](https://github.com/SaulHarwin/Computing-Project-Solar-System/blob/ae4af1ff050f822d48ce254e41cfec6a4ca0e449/Assets/Scripts/PlanetFace.cs#L26-L61).CunstructMesh() function:

```cs
public void ConstructMesh() {
    Vector3[] vertices = new Vector3[resolution * resolution];
    int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
    int triIndex = 0;


    for (var y = 0; y < resolution; y++) // Creates the vertices.
    {
        for (var x = 0; x < resolution; x++)
        {
            int i = x + y * resolution; // Finds the index.
            Vector2 percent = new Vector2(x, y) / (resolution - 1); // Shows how close to completion the 2 loops together are. Is used to define where the vertex should be along the face.
            Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2 * axisA + (percent.y - .5f) * 2 * axisB;
            Vector3 pointOnUnitSphere = pointOnUnitCube.normalized; // Normalises the point on unit cube to be a sphere.
            vertices[i] = shapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);


            if (x != resolution - 1 && y != resolution - 1) // As long as the vertex is not along the right or buttom edge of the Face.
            {
                triangles[triIndex] = i;
                triangles[triIndex + 1] = i + resolution + 1;
                triangles[triIndex + 2] = i + resolution;


                triangles[triIndex + 3] = i;
                triangles[triIndex + 4] = i + 1;
                triangles[triIndex + 5] = i + resolution + 1;
                triIndex += 6;
            }
        }
    }


    // Update mesh with the data.
    mesh.Clear();
    mesh.vertices = vertices;
    mesh.triangles = triangles;
    mesh.RecalculateNormals();
}
```

On the line 40 I call [ShapeGenerator](https://github.com/SaulHarwin/Computing-Project-Solar-System/blob/ae4af1ff050f822d48ce254e41cfec6a4ca0e449/Assets/Scripts/ShapeGenerator.cs).CalculatePointOnPlanet() like so:
```cs
vertices[i] = shapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);
```
```cs
public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere) {
    float elevation = noiseProcessor.Evaluate(pointOnUnitSphere);
    return pointOnUnitSphere * settings.planetRadius * (1+elevation);
}
```
In this Function [noiseProccesor](https://github.com/SaulHarwin/Computing-Project-Solar-System/blob/ae4af1ff050f822d48ce254e41cfec6a4ca0e449/Assets/Scripts/NoiseProcessor.cs).Evaluate() is called. And zooming into that we find this code.
```cs
public float Evaluate(Vector3 point) {
    float noiseValue = 0;
    float frequency = settings.frequency;
    float amplitude = settings.amplitude;

    for (var o = 0; o < settings.octaves; o++)
    {
        float v = noise.Evaluate(point * frequency + settings.offset);
        noiseValue += (v+1) * 0.5f * amplitude;
        frequency *= settings.lacunarity;
        amplitude *= settings.percistance;
    }
    return noiseValue * settings.amplitude;
}
```  

What this does is it calculates the noise values from the [noise](https://github.com/SaulHarwin/Computing-Project-Solar-System/blob/ae4af1ff050f822d48ce254e41cfec6a4ca0e449/Assets/Scripts/Noise.cs) function I have which returns a value based on the frequency, amplidue, lacunarity and percistance.
- **Frequency** is how fast the land scape goes from hill to valley over a distance.
- **Amplitude** is the magnitude of the hills.
- **Percistance** is how fast the amplitude increases over each octave. A percistance of 0.5 will mean that the amplitude halfs ever octave.
- **Lacunarity** is how fast the frequency increases over each octave. A lacunarity of 1.5 will mean that the frequency increases by 1.5 times ever octave.

After this the value is return back up to the [ShapeGenerator](https://github.com/SaulHarwin/Computing-Project-Solar-System/blob/ae4af1ff050f822d48ce254e41cfec6a4ca0e449/Assets/Scripts/ShapeGenerator.cs).CalculatePointOnPlanet() function which then translate the value into the planet surface with this line of code:
```cs
return pointOnUnitSphere * settings.planetRadius * (1+elevation);
```
