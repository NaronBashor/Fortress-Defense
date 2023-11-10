using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;

public class HelpLoreManager : MonoBehaviour
{
        [SerializeField] public List<GameObject> enemies = new List<GameObject>();

        [SerializeField] private int index;

        [SerializeField] private GameObject helpScreen;
        [SerializeField] private GameObject loreScreen;

        [SerializeField] private GameObject enemyIcon;
        [SerializeField] TextMeshProUGUI enemyName;
        [SerializeField] TextMeshProUGUI enemyDescription;
        [SerializeField] TextMeshProUGUI loreTitle;
        [SerializeField] TextMeshProUGUI loreDescription;

        [SerializeField] private Sprite boneBatRider;
        [SerializeField] private Sprite batbourneBomber;
        [SerializeField] private Sprite blazingBomberSkeleton;
        [SerializeField] private Sprite skelarspearSentinel;
        [SerializeField] private Sprite skeletrunkBrawlers;
        [SerializeField] private Sprite verdantNecromancer;
        [SerializeField] private Sprite hornedRevenant;
        [SerializeField] private Sprite ironcladGuardian;
        [SerializeField] private Sprite colassalBoneslasher;
        [SerializeField] private Sprite boulderbeastBruiser;
        [SerializeField] private Sprite warlordOfDesolation;

        private bool loreScreenOpen = false;

        private void Start()
        {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();

                loreScreen.SetActive(false);
                loreScreenOpen = false;
                index = 0;
                LoreInfo(index);
        }

        private void Update()
        {
                if (index == enemies.Count)
                {
                        index = 0;
                        LoreInfo(index);
                }
        }

        public void LoreInfo(int index)
        {
                if (index == 0)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = boneBatRider;
                        enemyName.text = "Bonebat Rider";
                        enemyDescription.text = "The Bonebat Rider is a menacing sight in the dark and eerie dungeons of our game world. It is a grotesque skeletal warrior and a giant bat. The skeletal warrior, clad in tattered, rotting armor, is hanging beneath the bat. The bat itself is a monstrous creature with leathery wings, mottled grey skin, and crimson, malevolent eyes. The rider grips a jagged, rusted sword in its bony hand, ready to strike at any intruders. Both the bat and the rider emit an eerie sound, casting an otherworldly aura around them.";
                        loreTitle.text = "The Cursed Bond of Bat and Bones";
                        loreDescription.text = "In a time long past, when the world was shrouded in darkness and plagued by malevolent forces, there existed a place known as the Shadowfen Vale. It was a desolate and treacherous land, said to be cursed by the spirits of those who had fallen in countless battles. In this forsaken realm, a sinister tale of an unholy bond unfolded—a bond between a bat and a fallen warrior that would forever haunt the land.  Centuries ago, a great war raged in Shadowfen Vale, pitting rival kingdoms against each other. Amidst the chaos and bloodshed, a valiant knight named Sir Elrik fought to protect his homeland. Sir Elrik was renowned for his bravery, wielding a mighty sword that was said to have the power to banish the darkness itself. His loyalty to his kingdom was unwavering, and he was prepared to lay down his life in defense of his people.  One fateful night, during the height of the conflict, a coven of dark sorcerers enacted a ritual to summon a powerful demon into the world. In their desperation, they sought to bind the demon to a loyal and powerful servant. In the twisted, arcane ritual, the demon's essence was unwittingly fused with that of a vampire bat that had been drawn to the dark magic. As the dark sorcerers chanted their incantations, the bat was drawn toward Sir Elrik, who was in the midst of a harrowing battle. The bat collided with the knight, and in that moment, an unholy fusion occurred. The knight's life was extinguished, and the bat absorbed his essence, leaving behind only Sir Elrik's skeletal remains. This fusion of a cursed bat and the valiant knight gave rise to a monstrous entity known as the  Blighted Reaver.  The Blighted Reaver became an instrument of chaos and terror in the Shadowfen Vale. It retained the knight's skills and combat prowess, wielding the enchanted sword with deadly precision, while the dark powers of the bat gave it an unnatural resilience and the ability to drain the life force of its victims. Legends of the Blighted Reaver spread throughout the land, and it became a harbinger of doom, feared by all who crossed its path. The cursed bond between the bat and the knight rendered them eternally linked, cursed to roam the Shadowfen Vale together, seeking to exact their unholy vengeance on those who intruded upon their cursed domain.  Adventurers who dare to enter the accursed Shadowfen Vale now face the relentless and malevolent Blighted Reaver, a creature forever bound to the knight's sense of duty and the bat's insatiable hunger for blood. It is a testament to the consequences of meddling with dark magic, and a chilling reminder of the horrors that can arise from the unending battle between light and shadow.";
                }
                else if (index == 1)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = batbourneBomber;
                        enemyName.text = "Batborne Bomber";
                        enemyDescription.text = "The Batborne Bomber is a sinister and unusual foe that haunts the depths of our game world. This grotesque duo consists of a monstrous bat, larger and more ferocious than any in the natural world, and a skeletal enemy hanging by its feet. The bat's wings are tattered and mangled, and its eyes glow with an eerie, malevolent light. The skeletal enemy is armed with a barrel of deadly, explosive bombs, ready to rain destruction upon any foe. Both the bat and the skeletal enemy are shrouded in an otherworldly, sickly aura.";
                        loreTitle.text = "The Cursed Bond of Bat and Bombs";
                        loreDescription.text = "The origins of the Batborne Bomber are shrouded in mystery, closely tied to a dark and ancient tale that unfolds in the forgotten annals of the game world's history.\r\n\r\nLong ago, in a kingdom plagued by war, a ruthless necromancer named Morvulak sought to create the ultimate aerial terror, one that would strike fear into the hearts of his enemies. In his pursuit of dark power, he stumbled upon a forbidden ritual that involved fusing a giant bat and the remains of a skilled alchemist named Gralken. Gralken, once renowned for his expertise in creating explosive concoctions, met a tragic end at the hands of the necromancer.\r\n\r\nIn the ritual, the necromancer bound Gralken's spirit to the giant bat, forming a malevolent and grotesque partnership. This unholy fusion gave birth to the Batborne Bomber, a creature with the alchemical knowledge of Gralken and the relentless aggression of the bat.\r\n\r\nThe Batborne Bomber is driven by a sinister purpose. It roams the skies, patrolling the kingdom's desolate battlefields, seeking to rain destruction upon any who dare encroach upon its territory. Gralken's knowledge of explosives, once used for scientific advancement, is now harnessed for wanton destruction, making the Batborne Bomber an unpredictable and formidable enemy.\r\n\r\nAdventurers who delve into the dark history of the kingdom are often met with the terrifying and explosive wrath of the Batborne Bomber, a chilling reminder of the consequences of tampering with forbidden magic and the relentless pursuit of power at any cost. Facing this malevolent duo is a true test of skill, courage, and adaptability.";
                }
                else if (index == 2)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = blazingBomberSkeleton;
                        enemyName.text = "Blazing Bomber Skeleton";
                        enemyDescription.text = "The Blazing Bomber Skeleton is a formidable and unearthly foe that haunts the depths of our game world. It is a skeletal warrior adorned in charred, tattered robes, its bones perpetually charred from flames. What makes this enemy truly unique is the enormous wooden barrel affixed to its back, containing a seemingly endless supply of volatile explosives. The Blazing Bomber Skeleton, casting an ominous aura in its wake.";
                        loreTitle.text = "Burning Bombardment";
                        loreDescription.text = "The origins of the Blazing Bomber Skeleton are rooted in a dark chapter of the game world's history, harking back to an era of alchemical experiments gone awry.\r\n\r\nIn the heart of a sprawling, ancient alchemical city, a group of ambitious scholars and mages sought to harness the elemental power of fire. Their experiments led them to uncover forbidden texts and long-forgotten rituals, revealing the secrets of fire manipulation and explosive concoctions. Eager to demonstrate their newfound power, they experimented recklessly with both magic and volatile materials.\r\n\r\nOne ill-fated day, a catastrophic explosion tore through the city's laboratories, consuming everything in its path. The mages, scholars, and apprentices were reduced to ashes, their souls bound to the elemental forces they had sought to control. What emerged from the ashes was the Blazing Bomber Skeleton—an amalgamation of skeletal remains fueled by the unquenchable fire.\r\n\r\nThe Blazing Bomber Skeleton, driven by an insatiable desire to unleash chaos, roams the desolate ruins of the alchemical city. Its burning bones, infused with the remnants of the volatile experiments, allow it to wield the power of fire in the form of explosive bombs. It serves as a relentless guardian, protecting the secrets of the alchemical city from intruders.\r\n\r\nAdventurers who venture into the scorched remnants of the city encounter the Blazing Bomber Skeleton, a chilling testament to the consequences of unchecked ambition and the destructive power of forbidden knowledge. Facing this fiery foe requires not only combat prowess but also a deep understanding of its fire-based abilities and a keen sense of timing to avoid its explosive attacks.";
                }
                else if (index == 3)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = skelarspearSentinel;
                        enemyName.text = "Skelarspear Sentinel";
                        enemyDescription.text = "The Skelarspear Sentinel is a fearsome adversary in our game, a skeletal warrior clad in tattered, ancient armor adorned with symbols of a long-forgotten kingdom. It wields a sturdy shield that bears no emblem, and in its bony hand, a wickedly sharp spear is poised for combat. The sentinel's single eye socket burn with an eerie, ethereal light, casting an unsettling glow upon its surroundings. This skeletal foe exudes an aura of unyielding determination and an unwavering commitment to take down its foe.";
                        loreTitle.text = "Fear of Spears";
                        loreDescription.text = "The legend of the Skelarspear Sentinels originates in a kingdom steeped in both glory and tragedy. In the distant past, the Kingdom of Veridora was renowned for its advanced culture, dedication to honor, and the might of its guardian knights. These knights, called the Veridoran Sentinels, were tasked with protecting the kingdom's sacred treasures and maintaining the peace.\r\n\r\nOne of the most revered of these Sentinels was Sir Aric of the Golden Crest, a hero of unmatched valor and loyalty. Sir Aric's unwavering dedication to his kingdom and his people earned him the right to be among the first to undergo a unique ritual. The ritual, known as the \"Rite of Eternal Vigil,\" bound the spirits of the kingdom's most dedicated knights to their skeletal remains, enabling them to serve even in death.\r\n\r\nHowever, tragedy struck when an evil sorcerer's curse swept across the land, plunging the once-prosperous kingdom into darkness. The Veridora Kingdom fell into ruin, and the spirits of the kingdom's protectors were cursed to roam the land as relentless skeletal warriors, guarding their posts and the remnants of their former glory.\r\n\r\nThe Skelarspear Sentinels now stand as the last vestiges of a bygone era, determined to fulfill their duty even in undeath. They patrol the decaying ruins of the Veridora Kingdom, protecting what little remains of their kingdom's treasures from any who dare intrude. The Sentinels' loyalty and sense of honor persist, and they view all who approach as potential threats to their kingdom's legacy.\r\n\r\nAdventurers who cross paths with the Skelarspear Sentinels must not only face their formidable combat skills but also contemplate the tragic fate that has befallen these once-noble knights. Defeating them is not just a matter of strength but also a test of understanding and respect for the kingdom's history.";
                }
                else if (index == 4)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = skeletrunkBrawlers;
                        enemyName.text = "Skeletrunk Brawlers";
                        enemyDescription.text = "The Skeletrunk Brawlers are an imposing and unconventional enemy encountered in our game world. This formidable duo consists of two skeletal warriors, each supporting one end of a massive, gnarled tree trunk that has been repurposed into a battering ram. Their skeletal frames are adorned in scraps of ancient armor, and their empty eye sockets glow with an eerie, ghostly light. The skeletal warriors are connected by a spectral, ethereal tether, allowing them to coordinate their movements with uncanny precision. The entire ensemble exudes an aura of raw power and relentless determination.";
                        loreTitle.text = "Trees Become Weapons";
                        loreDescription.text = "The tale of the Skeletrunk Brawlers is a chilling story from the ancient, mystical Forest of Eldertrees, a place of secrets and enigmas that have captivated adventurers for centuries.\r\n\r\nDeep within the heart of the Forest of Eldertrees, there existed a sacred grove, hidden from the eyes of the outside world. In this sacred place, a unique and powerful ritual was conducted by a group of forest-dwelling druids. The ritual aimed to bind the spirits of the ancient, towering trees to the spirits of warriors who had sworn to protect the forest at all costs. These warriors, known as the Guardians of the Sylvan Grove, made a solemn vow to ensure the safety and prosperity of the forest for all time.\r\n\r\nHowever, when a calamity of unparalleled darkness befell the forest, it unleashed malevolent forces that disrupted the ritual. The trees and the warriors' spirits became ensnared by the same darkness, giving rise to the Skeletrunk Brawlers. These entities are now forever bound to the gnarled tree trunk they wield, consumed by an unrelenting urge to protect their sacred grove.\r\n\r\nThe Skeletrunk Brawlers now stand as sentinels of the Forest of Eldertrees, guardians who have been transformed into menacing enemies by the very forces they once swore to protect. They patrol the dark and twisted remnants of the sacred grove, attacking any intruders with their colossal battering ram. In their spectral state, they hold no distinction between friend and foe, treating all who approach as threats to the forest's well-being.\r\n\r\nAdventurers who venture into the Forest of Eldertrees must confront the Skeletrunk Brawlers, facing not only their formidable combat abilities but also the tragic tale of guardians who became twisted by the very powers they sought to harness for the greater good. Defeating them becomes a matter of not only strength but also unraveling the mysteries of the forest's dark past and ultimately restoring balance to the ancient grove.\r\n\r\n\r\n\r\n\r\n";
                }
                else if (index == 5)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = verdantNecromancer;
                        enemyName.text = "Verdant Necromancer";
                        enemyDescription.text = "The Verdant Necromancer is a menacing and enigmatic figure in our game world. This skeletal mage is cloaked in a tattered, deep crimson robe that billows as if touched by an otherworldly wind. A wooden staff, adorned with carved skulls and intertwined with vivid green leaves at its apex, is clutched in its bony hand. The eerie, ethereal light within the necromancer's empty eye sockets flickers with malevolent energy, casting a haunting presence.";
                        loreTitle.text = "Menacing Mage";
                        loreDescription.text = "The lore of the Verdant Necromancer originates in a mysterious, long-forgotten forest known as the Sylvan Veil, a place where the boundaries between life and death were once blurred by ancient rituals and the flow of primal magic.\r\n\r\nIn the heart of the Sylvan Veil, a circle of druidic guardians known as the Eldertree Keepers maintained the balance of nature. They were renowned for their ability to communicate with the spirits of the forest and maintain harmony between the living and the departed. However, one fateful day, a renegade member of their order, known as Vorenthas the Verdant, sought forbidden power to command the forces of nature and death.\r\n\r\nVorenthas delved into the darkest aspects of necromancy, aiming to harness the innate magic of the Sylvan Veil. The rituals he performed were an abomination to the Eldertree Keepers, who had always sought to uphold the sanctity of life and death. In his quest for power, Vorenthas became an avatar of decay and darkness, and his actions desecrated the sacred groves of the Sylvan Veil.\r\n\r\nThe Eldertree Keepers, unable to sway their fallen comrade, were forced to take extreme measures, sealing Vorenthas in an ethereal prison within the very staff he wielded. However, this act only served to further corrupt him, transforming Vorenthas into the Verdant Necromancer, a skeletal mage who now wielded the power of life and death.\r\n\r\nThe Verdant Necromancer now guards the Sylvan Veil, wielding his twisted, dark magic and summoning undead flora to thwart any intruders. He represents the dark side of the forest's balance, an embodiment of what happens when the sanctity of life and death is disrupted.\r\n\r\nAdventurers who enter the Sylvan Veil must confront the Verdant Necromancer, both as a powerful adversary and as a tragic figure whose lust for power led to his own corruption. Defeating him requires not just strength but a deep understanding of the forest's magic and the ability to restore the balance of life and death to the Sylvan Veil.";
                }
                else if (index == 6)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = hornedRevenant;
                        enemyName.text = "Horned Revenant";
                        enemyDescription.text = "The Horned Revenant is a formidable and imposing adversary in our game world. It is a skeletal warrior clad in tattered, ancient garments that hang loosely from its bony frame. A horned helmet rests upon its skull, and it wields an enormous, weathered greatsword, a testament to its past as a formidable warrior. The Revenant's empty eye sockets burn with an eerie, spectral light, casting an intimidating presence.";
                        loreTitle.text = "The Cursed GreatSword";
                        loreDescription.text = "The tale of the Horned Revenant is a somber and tragic one, hailing from an age of turmoil and warfare within the game world.\r\n\r\nIn a time long past, the Kingdom of Baelthorne was embroiled in a brutal and unending war, its lands marred by conflict and strife. Amid the chaos, a valiant warrior named Sir Haldrick earned great renown for his loyalty and bravery on the battlefield. Wearing his distinctive horned helmet and wielding a colossal greatsword, Sir Haldrick was a symbol of hope for his people.\r\n\r\nHowever, as the war raged on and the kingdom's fortunes dwindled, Sir Haldrick found himself embroiled in a plot of treachery and betrayal. A close comrade, Lord Tarelion, driven by jealousy and a lust for power, conspired to frame Sir Haldrick for treason, leading to his unjust execution. The kingdom, under Lord Tarelion's rule, descended into even darker times.\r\n\r\nBut the story did not end with Sir Haldrick's execution. Unbeknownst to his betrayers, his spirit remained bound to his mortal remains. Over the years, Sir Haldrick's vengeful spirit, fueled by a desire for justice, rose from the grave to become the Horned Revenant.\r\n\r\nNow, the Horned Revenant roams the battle-scarred lands, seeking retribution against those who wronged him and the dark forces that tainted the kingdom. The warrior's spirit, forever trapped within the skeletal frame, wields his greatsword with an unquenchable thirst for vengeance.\r\n\r\nAdventurers who encounter the Horned Revenant must face a being driven by a tragic history of betrayal and a deep desire for retribution. Defeating this formidable foe is not just a test of strength but a reckoning with the injustices of the past, allowing Sir Haldrick's spirit to find peace once and for all.\r\n\r\n\r\n\r\n\r\n\r\n";
                }
                else if (index == 7)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = ironcladGuardian;
                        enemyName.text = "Ironclad Guardian";
                        enemyDescription.text = "The Ironclad Guardian is a formidable and disciplined adversary in our game world. This skeletal warrior is adorned in the remnants of a once-proud suit of iron armor, complete with a helmet and a well-crafted sword and shield. Its empty eye sockets burn with an eerie, ethereal light, giving it an intimidating and relentless presence.";
                        loreTitle.text = "Once A Warrior";
                        loreDescription.text = "The legend of the Ironclad Guardian harks back to an era of knights and chivalry in a kingdom now long forgotten, the Kingdom of Valoria.\r\n\r\nIn the golden age of Valoria, a band of elite knights, known as the Valorian Guardians, were sworn to protect the realm's royal family and its cherished treasures. One knight in particular, Sir Alaric the Loyal, was known for his unwavering dedication to his duty and unbreakable loyalty to the king and queen.\r\n\r\nHowever, as time passed, the kingdom fell victim to treacherous plots and sinister conspiracies. A group of corrupt courtiers orchestrated a coup against the monarchy, seeking to seize power and wealth for themselves. In the ensuing chaos, the royal family and their loyal knights were betrayed and cast into exile. Among those knights was Sir Alaric, who faced unjust persecution and was ultimately executed by the conspirators.\r\n\r\nBut the knight's spirit, unwavering in its loyalty to the crown, refused to rest. It became bound to its suit of iron armor, becoming the Ironclad Guardian. This spectral warrior now roams the forsaken ruins of Valoria, guarding the kingdom's buried treasures and the memory of the monarchy it once served.\r\n\r\nThe Ironclad Guardian stands as a testament to the forgotten history of Valoria, a kingdom betrayed and a knight's unyielding loyalty to his fallen rulers. Adventurers who cross paths with the guardian face not just a formidable enemy but also a somber reminder of the consequences of betrayal and the enduring legacy of honor. Defeating the guardian is a matter of not only strength but also a symbol of justice served to those who betrayed the crown.\r\n\r\n\r\n\r\n\r\n\r\n";
                }
                else if (index == 8)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = colassalBoneslasher;
                        enemyName.text = "Colassal Boneslasher";
                        enemyDescription.text = "The Colossal Boneslasher is a fearsome and imposing adversary in our game world. This immense skeletal warrior is adorned in tattered and ancient garments that hang loosely from its towering skeletal frame. Clutched in its bony hand is a colossal, weathered sword with a blade that seems to crackle with spectral energy. Its empty eye sockets flicker with an eerie, ethereal light, casting a haunting and commanding presence.";
                        loreTitle.text = "The Cursed Bond of Bat and Bones";
                        loreDescription.text = "The tale of the Colossal Boneslasher is a saga of an ancient, long-lost civilization, known as the Ruins of Serathar, and the tragic fate that befell its once-mighty guardians.\r\n\r\nIn an era of long-forgotten empires, the Ruins of Serathar stood as a beacon of prosperity and enlightenment. It was a realm renowned for its rich culture and powerful guardians who had sworn to protect the kingdom's treasures and its people. These guardians, known as the Sentinels of Serathar, were esteemed for their unwavering dedication and formidable combat prowess.\r\n\r\nHowever, as the civilization of Serathar reached its zenith, dark forces began to encroach upon the realm. An enigmatic necromancer named Zarael sought to harness the power of the afterlife to gain dominion over life and death itself. In a desperate bid to stop the necromancer's conquest, the Sentinels engaged Zarael in a cataclysmic battle.\r\n\r\nThe battle culminated in an explosion of dark magic that engulfed the Sentinels and transformed them into colossal skeletal warriors, the Colossal Boneslashers. Their once-mighty purpose was now perverted into a never-ending sentinel of the ruins, bound to guard the kingdom's remnants and thwart intruders.\r\n\r\nThe Colossal Boneslashers now patrol the decaying Serathar, their colossal swords and spectral auras serving as a grim reminder of the fate that befell their kingdom. They are the spectral guardians of a forgotten realm, now twisted by dark magic and ensnared in an eternal struggle against any who dare desecrate their homeland.\r\n\r\nAdventurers who venture into the Ruins of Serathar must confront the Colossal Boneslasher, a symbol of a once-great civilization's fall from grace and the tragic destiny of its noble protectors. Defeating this colossal enemy is not just a matter of strength but also an act of reconciliation with a kingdom's troubled history and an opportunity to restore its legacy.";
                }
                else if (index == 9)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = boulderbeastBruiser;
                        enemyName.text = "Boulderbeast Bruiser";
                        enemyDescription.text = "The Boulderbeast Bruiser is a colossal and intimidating adversary in our game world. Towering over its foes, this massive creature is draped in tattered, ancient clothing that barely conceals its massive frame. A horned helmet perches atop its head, giving it an even more menacing visage. The Bruiser wields a gigantic boulder as its weapon, hoisted with colossal strength. Its baleful, glowing eyes fixate upon its targets with an eerie, ethereal light, casting a fearsome presence.";
                        loreTitle.text = "The Cursed Bond of Bat and Bones";
                        loreDescription.text = "The lore of the Boulderbeast Bruiser emerges from the craggy and unforgiving mountains known as the Spine of Ymir, a land rife with both treacherous terrain and the echoes of ancient legends.\r\n\r\nIn the heart of the Spine of Ymir, an isolated tribe of mountain dwellers lived for generations, their existence tightly bound to the rugged landscape and the secrets of the region. They thrived by extracting precious resources from the mountains and erecting mighty fortifications to protect their home.\r\n\r\nA grave misfortune befell the mountain dwellers when a series of cataclysmic quakes shook the region, causing an avalanche that decimated their tribe. The tribe's chieftain, a hulking warrior known as Thranok the Mighty, had fought valiantly to save his people but was crushed beneath a colossal boulder in the disaster.\r\n\r\nMiraculously, Thranok's spirit refused to be extinguished, and he became one with the very boulder that had claimed his life. With a newfound purpose, Thranok became the Boulderbeast Bruiser, determined to protect his people's ancestral homeland even in death.\r\n\r\nNow, the Boulderbeast Bruiser roams the treacherous slopes of the Spine of Ymir, guarding the secrets of his tribe and unleashing devastating attacks upon any who venture too close. His fearsome presence is both a tribute to his loyalty and a testament to the enduring spirit of the mountain dwellers.\r\n\r\nAdventurers who explore the unforgiving Spine of Ymir must confront the Boulderbeast Bruiser, not only as a powerful enemy but also as a guardian who embodies the indomitable spirit of a tribe brought low by nature's wrath. To defeat this colossal foe is not just a matter of strength but an act of reverence for the fallen mountain dwellers and the preservation of their ancient legacy.\r\n\r\n\r\n\r\n\r\n\r\n";
                }
                else if (index == 10)
                {
                        var image = enemyIcon.GetComponent<UnityEngine.UI.Image>();
                        image.sprite = warlordOfDesolation;
                        enemyName.text = "Warlord of Desolation";
                        enemyDescription.text = "The Warlord of Desolation is a titanic and nightmarish boss in our game world, a harbinger of darkness and destruction. This colossal, four-legged creature is a dark, ashen gray, with thick, mottled hide that exudes an aura of malevolence. It bears two immense, gnarled tusks. A colossal harness, constructed of leather and chains, adorns its body, and on its back are harnessed three skeletal minions, bound to serve their master. The beast carries the flags of the enemy, a chilling emblem of their alliance, a testament to the savage ferocity of its existence.";
                        loreTitle.text = "The Cursed Bond of Bat and Bones";
                        loreDescription.text = "The legend of the Warlord of Desolation is a grim and sinister saga, set in a land where darkness and tyranny have long held sway—the Shadowlands.\r\n\r\nThe Shadowlands were once a realm of unparalleled beauty, a place where people thrived in the embrace of nature's splendor. However, the peace of the land was shattered when the Warlord of Desolation, a malevolent conqueror, seized control of the realm and imposed a reign of terror and chaos.\r\n\r\nBound by a relentless hunger for power, the Warlord turned to the dark arts and formed an unholy pact with malevolent forces. This pact granted the Warlord the ability to control skeletal minions, fallen warriors bound to serve his dark ambitions. Together, they terrorized the Shadowlands, pillaging, and enslaving its inhabitants.\r\n\r\nThe battle was cataclysmic, leaving the Shadowlands ravaged and scarred. The hero, Azarion, was ultimately victorious, but at a great cost. The Warlord of Desolation was defeated, and his malevolent spirit was bound within the colossal, nightmarish form that it had assumed.\r\n\r\nNow, as the Warlord of Desolation, the entity roams the Shadowlands, a tormented spirit imprisoned by its lust for power. It is forever accompanied by its three skeletal minions, symbols of its once-dreaded army. The land has been left in a state of desolation, bearing the scars of the battles fought.\r\n\r\nAdventurers who journey to the Shadowlands must face the colossal and malevolent Warlord of Desolation, not only as a powerful boss but as a reminder of the consequences of unchecked ambition and the enduring legacy of the realm's defenders. Defeating the Warlord becomes a symbol of the Shadowlands' redemption and an opportunity to restore balance to the land.";
                }
        }

        public void RightButton()
        {
                index++;
                LoreInfo(index);
        }

        public void LeftButton()
        {
                index--;
                if (index < 0)
                {
                        index = enemies.Count - 1;
                }
                LoreInfo(index);
        }

        public void LoreButton()
        {
                if (!loreScreenOpen)
                {
                        loreScreen.SetActive(true);
                        helpScreen.SetActive(false);
                        loreScreenOpen = true;
                }
                else if (loreScreenOpen)
                {
                        loreScreen.SetActive(false);
                        helpScreen.SetActive(true);
                        loreScreenOpen = false;
                }
        }
}
