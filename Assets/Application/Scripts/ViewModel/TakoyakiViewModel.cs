﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class TakoyakiViewModel : SingletonMonoBehaviour<TakoyakiViewModel>{

    [HideInInspector]
    public TakoyakiModel[] takoyakis = {new TakoyakiModel(),new TakoyakiModel(),new TakoyakiModel(),
                                        new TakoyakiModel(),new TakoyakiModel(),new TakoyakiModel()};
    public GameObject tepan;
    public HoleView holeViewPrefab;
    
    // Start is called before the first frame update
    void Start(){
        CreateHoles();
    }

    // Update is called once per frame
    void Update(){
        float bakeTimeLevelMedium = 5.0f;
        float bakeTimeLevelWelldone = 10.0f;

        foreach (TakoyakiModel tako in takoyakis) {
            if (tako.bakeState != TakoyakiModel.BakeState.blank) {
                tako.bakeTime += Time.deltaTime;
                if (tako.bakeTime > bakeTimeLevelWelldone)
                {
                    tako.bakeState = TakoyakiModel.BakeState.welldone;
                }
                else if (tako.bakeTime > bakeTimeLevelMedium)
                {
                    tako.bakeState = TakoyakiModel.BakeState.medium;
                }
            }
        }


    }

    public void IntoTakoyakiEki(TakoyakiModel t) {
        if (t.bakeState == TakoyakiModel.BakeState.blank){
            t.bakeState = TakoyakiModel.BakeState.rare;
            t.bakeTime = 0f;
         }
    }


    void CreateHoles() {
        foreach(TakoyakiModel tako in takoyakis) {
            HoleView.Instantiate(holeViewPrefab.gameObject, this.tepan,tako);
        }
    }

}
