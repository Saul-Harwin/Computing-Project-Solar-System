using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlanetData : MonoBehaviour {
    static double offset = 0;

    static double sunWeight = 1.99E+30;
    static double mercuryWeight = 3.30E+23;
    static double venusWeight = 4.87E+24;
    static double earthWeight = 5.97E+24;
    static double moonWeight = 7.35E+22;
    static double marsWeight = 6.42E+23;
    static double jupiterWeight = 1.90E+27;
    static double saturnWeight = 5.68E+26;
    static double uranusWeight = 8.68E+25;
    static double neptuneWeight = 1.02E+26;

    static float sunRadius = 696000;
    static float mercuryRadius= 2439;
    static float venusRadius = 6051;
    static float earthRadius = 6378;
    static float moonRadius = 1738;
    static float marsRadius = 3393;
    static float jupiterRadius = 71492;
    static float saturnRadius = 60268;
    static float uranusRadius = 25559;
    static float neptuneRadius = 24764;

    static float sunDistanceFromSun = 0 + (float)offset;
    static float mercuryDistanceFromSun = 57900000000 + (float)offset;
    static float venusDistanceFromSun = 108200000000 + (float)offset;
    static float earthDistanceFromSun = 149600000000 + (float)offset;
    static float moonDistanceFromSun = 384400000 + (float)offset; // Issue because this is around earth not the sun
    static float marsDistanceFromSun = 227900000000 + (float)offset;
    static float jupiterDistanceFromSun = 778600000000 + (float)offset;
    static float saturnDistanceFromSun = 1433500000000 + (float)offset;
    static float uranusDistanceFromSun = 2872500000000 + (float)offset;
    static float neptuneDistanceFromSun = 4495100000000 + (float)offset;

    static float sunOrbitalSpeed = 0;
    static float mercuryOrbitalSpeed = 47870;
    static float venusOrbitalSpeed = 35020;
    static float earthOrbitalSpeed = 29780;
    static float moonOrbitalSpeed = 1022;
    static float marsOrbitalSpeed = 24077;
    static float jupiterOrbitalSpeed = 13070;
    static float saturnOrbitalSpeed = 9690;
    static float uranusOrbitalSpeed = 6810;
    static float neptuneOrbitalSpeed = 5430;

    static double sunOrbitalAngle = 0;
    static double mercuryOrbitalAngle = 7;
    static double venusOrbitalAngle = 3.24;
    static double earthOrbitalAngle = 0;
    static double moonOrbitalAngle = 0;
    static double marsOrbitalAngle = 1.51;
    static double jupiterOrbitalAngle = 1.18;
    static double saturnOrbitalAngle = 2.29;
    static double uranusOrbitalAngle = 0.46;
    static double neptuneOrbitalAngle = 1.46;

    public double G = 6.67408E-11;

//  -- SCALING --
    public float timeMultiplier = 1;
    public double scaleFactor = 1;
    public double scaleFactorPlanets = 1;
    public double ScaledG = 1;
    public double scaleFactorMass;

    public double ScaledSunWeight;
    public double ScaledMercuryWeight;
    public double ScaledVenusWeight;
    public double ScaledEarthWeight;
    public double ScaledMoonWeight;
    public double ScaledMarsWeight;
    public double ScaledJupiterWeight;
    public double ScaledSaturnWeight;
    public double ScaledUranusWeight;
    public double ScaledNeptuneWeight;

    public double ScaledSunRadius;
    public double ScaledMercuryRadius;
    public double ScaledVenusRadius;
    public double ScaledEarthRadius;
    public double ScaledMoonRadius;
    public double ScaledMarsRadius;
    public double ScaledJupiterRadius;
    public double ScaledSaturnRadius;
    public double ScaledUranusRadius;
    public double ScaledNeptuneRadius;

    public double ScaledSunDistanceFromSun;
    public double ScaledMercuryDistanceFromSun;
    public double ScaledVenusDistanceFromSun;
    public double ScaledEarthDistanceFromSun;
    public double ScaledMoonDistanceFromSun;
    public double ScaledMarsDistanceFromSun;
    public double ScaledJupiterDistanceFromSun;
    public double ScaledSaturnDistanceFromSun;
    public double ScaledUranusDistanceFromSun;
    public double ScaledNeptuneDistanceFromSun;

    public double ScaledSunOrbitalSpeed;
    public double ScaledMercuryOrbitalSpeed;
    public double ScaledVenusOrbitalSpeed;
    public double ScaledEarthOrbitalSpeed;
    public double ScaledMoonOrbitalSpeed;
    public double ScaledMarsOrbitalSpeed;
    public double ScaledJupiterOrbitalSpeed;
    public double ScaledSaturnOrbitalSpeed;
    public double ScaledUranusOrbitalSpeed;
    public double ScaledNeptuneOrbitalSpeed;


    public double[] planetData_;
    void Start() {
        CalculateScaledValues();
        planetData_ = new double[]{ScaledSunWeight, ScaledMercuryWeight, ScaledVenusWeight, ScaledEarthWeight, ScaledMoonWeight, ScaledMarsWeight, ScaledJupiterWeight, ScaledSaturnWeight, ScaledUranusWeight, ScaledNeptuneWeight, ScaledSunRadius, ScaledMercuryRadius, ScaledVenusRadius, ScaledEarthRadius, ScaledMoonRadius, ScaledMarsRadius, ScaledJupiterRadius, ScaledSaturnRadius, ScaledUranusRadius, ScaledNeptuneRadius, ScaledSunDistanceFromSun, ScaledMercuryDistanceFromSun, ScaledVenusDistanceFromSun, ScaledEarthDistanceFromSun, ScaledMoonDistanceFromSun, ScaledMarsDistanceFromSun, ScaledJupiterDistanceFromSun, ScaledSaturnDistanceFromSun, ScaledUranusDistanceFromSun, ScaledNeptuneDistanceFromSun, ScaledSunOrbitalSpeed, ScaledMercuryOrbitalSpeed, ScaledVenusOrbitalSpeed, ScaledEarthOrbitalSpeed, ScaledMoonOrbitalSpeed, ScaledMarsOrbitalSpeed, ScaledJupiterOrbitalSpeed, ScaledSaturnOrbitalSpeed, ScaledUranusOrbitalSpeed, ScaledNeptuneOrbitalSpeed, sunOrbitalAngle, mercuryOrbitalAngle, venusOrbitalAngle, earthOrbitalAngle, moonOrbitalAngle, marsOrbitalAngle, jupiterOrbitalAngle, saturnOrbitalAngle, uranusOrbitalAngle, neptuneOrbitalAngle, ScaledG};
        gameObject.GetComponent<PlanetSizes>().Do(planetData_);
    }

    // void Update() {
    //     CalculateScaledValues();
    //     planetData_ = new double[]{ScaledSunWeight, ScaledMercuryWeight, ScaledVenusWeight, ScaledEarthWeight, ScaledMoonWeight, ScaledMarsWeight, ScaledJupiterWeight, ScaledSaturnWeight, ScaledUranusWeight, ScaledNeptuneWeight, ScaledSunRadius, ScaledMercuryRadius, ScaledVenusRadius, ScaledEarthRadius, ScaledMoonRadius, ScaledMarsRadius, ScaledJupiterRadius, ScaledSaturnRadius, ScaledUranusRadius, ScaledNeptuneRadius, ScaledSunDistanceFromSun, ScaledMercuryDistanceFromSun, ScaledVenusDistanceFromSun, ScaledEarthDistanceFromSun, ScaledMoonDistanceFromSun, ScaledMarsDistanceFromSun, ScaledJupiterDistanceFromSun, ScaledSaturnDistanceFromSun, ScaledUranusDistanceFromSun, ScaledNeptuneDistanceFromSun, ScaledSunOrbitalSpeed, ScaledMercuryOrbitalSpeed, ScaledVenusOrbitalSpeed, ScaledEarthOrbitalSpeed, ScaledMoonOrbitalSpeed, ScaledMarsOrbitalSpeed, ScaledJupiterOrbitalSpeed, ScaledSaturnOrbitalSpeed, ScaledUranusOrbitalSpeed, ScaledNeptuneOrbitalSpeed, sunOrbitalAngle, mercuryOrbitalAngle, venusOrbitalAngle, earthOrbitalAngle, moonOrbitalAngle, marsOrbitalAngle, jupiterOrbitalAngle, saturnOrbitalAngle, uranusOrbitalAngle, neptuneOrbitalAngle, ScaledG};
    //     gameObject.GetComponent<PlanetSizes>().Do(planetData_);
    // }

    void CalculateScaledValues() {
        this.ScaledSunWeight = sunWeight * scaleFactorMass * scaleFactor;
        this.ScaledMercuryWeight = mercuryWeight * scaleFactorMass * scaleFactor;
        this.ScaledVenusWeight = venusWeight * scaleFactorMass * scaleFactor;
        this.ScaledEarthWeight = earthWeight * scaleFactorMass * scaleFactor;
        this.ScaledMoonWeight = moonWeight * scaleFactorMass * scaleFactor;
        this.ScaledMarsWeight = marsWeight * scaleFactorMass * scaleFactor;
        this.ScaledJupiterWeight = jupiterWeight * scaleFactorMass * scaleFactor;
        this.ScaledSaturnWeight = saturnWeight * scaleFactorMass * scaleFactor;
        this.ScaledUranusWeight = uranusWeight * scaleFactorMass * scaleFactor;
        this.ScaledNeptuneWeight = neptuneWeight * scaleFactorMass * scaleFactor;

        this.ScaledSunRadius = sunRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledMercuryRadius = mercuryRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledVenusRadius = venusRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledEarthRadius = earthRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledMoonRadius = moonRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledMarsRadius = marsRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledJupiterRadius = jupiterRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledSaturnRadius = saturnRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledUranusRadius = uranusRadius * scaleFactor * scaleFactorPlanets;
        this.ScaledNeptuneRadius = neptuneRadius * scaleFactor * scaleFactorPlanets;

        this.ScaledSunDistanceFromSun = sunDistanceFromSun * scaleFactor;
        this.ScaledMercuryDistanceFromSun = mercuryDistanceFromSun * scaleFactor;
        this.ScaledVenusDistanceFromSun = venusDistanceFromSun * scaleFactor;
        this.ScaledEarthDistanceFromSun = earthDistanceFromSun * scaleFactor;
        this.ScaledMoonDistanceFromSun = (moonDistanceFromSun / ScaledMoonRadius) * scaleFactor;
        this.ScaledMarsDistanceFromSun = marsDistanceFromSun * scaleFactor;
        this.ScaledJupiterDistanceFromSun = jupiterDistanceFromSun * scaleFactor;
        this.ScaledSaturnDistanceFromSun = saturnDistanceFromSun * scaleFactor;
        this.ScaledUranusDistanceFromSun = uranusDistanceFromSun * scaleFactor;
        this.ScaledNeptuneDistanceFromSun = neptuneDistanceFromSun * scaleFactor;

        this.ScaledSunOrbitalSpeed = sunOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledMercuryOrbitalSpeed = mercuryOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledVenusOrbitalSpeed = venusOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledEarthOrbitalSpeed = earthOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledMoonOrbitalSpeed = moonOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledMarsOrbitalSpeed = marsOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledJupiterOrbitalSpeed = jupiterOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledSaturnOrbitalSpeed = saturnOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledUranusOrbitalSpeed = uranusOrbitalSpeed * scaleFactor * timeMultiplier;
        this.ScaledNeptuneOrbitalSpeed = neptuneOrbitalSpeed * scaleFactor * timeMultiplier;

        this.ScaledG = G;

    }
}

