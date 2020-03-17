﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillPlacement : MonoBehaviour
{
    #region Variables
    [Header("Skill Properties")]
    public GameObject skillPrefab;
    public string nameOfTheSkill = null;
    private skill skill = null;

    [Header("Visual Properties")]
    [SerializeField] private GameObject infoPanel = null;
    [SerializeField] private GameObject lockIcon = null;
    [SerializeField] private GameObject skillIcon = null;
    [SerializeField] private Text skillLevelRequire = null;


    private InventorySkill _Inventory;
    private Player _Player;

    public skill Skill { get => skill; }
    public GameObject InfoPanel { get => infoPanel; set => infoPanel = value; }
    #endregion

    #region Unity's MEthods
    private void Start()
    {
        _Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySkill>();
        _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        skill = _Inventory.GetASkill(nameOfTheSkill);
        skillLevelRequire.text = skill.LevelRequierement.ToString();
        infoPanel.SetActive(false);
    }

    void Update()
    {
        if (!skill.IsLocked()) return;

        if (_Player.levelCurrent >= skill.LevelRequierement)
        {
            skill.Unlock();
            gameObject.GetComponent<Button>().interactable = true;
            lockIcon.SetActive(false);
            skillIcon.SetActive(true);
        }
        else if(skill.IsLocked())
        {
            gameObject.GetComponent<Button>().interactable = false;
            lockIcon.SetActive(true);
            skillIcon.SetActive(false);
        }
        
    }


    #endregion

    #region Methods
    //Permet de l'utiliser dans un event systeme
    public void OnClickUpgrade()
    {
            UpgradeSkill(skill);
    }
    //Le meme code mais on demande un skill au lieu de rentrer tous manuellement
    private void UpgradeSkill(skill _skill)
    {
        if (_Player.SkillPoints <= 0 || _skill.IsMaxLevel()) return;

        if (_skill.Learned)
            _skill.CurrentUpgrade++;
        else
        {
            _skill.LearnSkill();
            InstantiateSkill();
        }
        _Player.SkillPoints--;

        infoPanel.GetComponent<InfoBox>().UpdateInfoBox();
    }
    void InstantiateSkill()
    {
        for (int i = 0; i < _Inventory.slots.Length; i++)
        {
            if (_Inventory.isFull[i] == false)
            {
                _Inventory.isFull[i] = true;

               GameObject clone = Instantiate(skillPrefab, _Inventory.slots[i].transform, false);
                clone.transform.position = _Inventory.slots[i].transform.position;
                    break;
            }
        }
    }

    #endregion

    #region Panel Methods
    public void ShowPanel()
    {
        infoPanel.SetActive(true);
    }
    public void HidePanel()
    {
        infoPanel.SetActive(false);
    }
    #endregion
}
